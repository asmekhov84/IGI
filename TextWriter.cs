using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace IGI
{
    // класс реализации методов растрового отображения текста
    public class TextRenderer
    {
        public readonly Bitmap _textBitmap;
        public int _textureId;
        public Size _clientSize;
        public Brush _textColor;
        public Graphics _gfx;

        public TextRenderer(Size clientSize)
        {
            _textBitmap = new Bitmap(clientSize.Width, clientSize.Height);
            _gfx = Graphics.FromImage(_textBitmap);
            _gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            _textureId = CreateTexture();
            _clientSize = clientSize;
        }

        public void Dispose()
        {
            if (_textureId > 0)
            {
                _textColor.Dispose();
                _textBitmap.Dispose();
                _gfx.Dispose();
                GL.DeleteTexture(_textureId);
            }
        }

        public void SetText(string text, Point pnt, Font textFont, Brush textColor)
        {
            // отрисовка текста на поверхности рисования GDI+
            _gfx.DrawString(text, textFont, textColor, pnt);
        }

        public void Draw()
        {
            Rectangle rect = new Rectangle(0, 0, _textBitmap.Width, _textBitmap.Height);
            BitmapData data = _textBitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, _textBitmap.Width, _textBitmap.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            _textBitmap.UnlockBits(data);
            GL.PushMatrix();
            GL.LoadIdentity();
            Matrix4 ortho_projection = Matrix4.CreateOrthographicOffCenter(0, _clientSize.Width, _clientSize.Height, 0, -1, 10000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadMatrix(ref ortho_projection);
            GL.Enable(EnableCap.Blend);                   // прозрачность OneMinusSrcColor SrcColor
            GL.BlendFunc(BlendingFactorSrc.SrcColor, BlendingFactorDest.SrcColor);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, _textureId);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1); GL.Vertex2(0, _clientSize.Height);
            GL.TexCoord2(1, 1); GL.Vertex2(_clientSize.Width, _clientSize.Height);
            GL.TexCoord2(1, 0); GL.Vertex2(_clientSize.Width, 0);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.End();
            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
            _gfx.Clear(Color.FromArgb(255, 170, 170, 175));
        }

        private int CreateTexture()
        {
            int textureId;
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Replace); //Important, or wrong color on some computers
            Bitmap bitmap = _textBitmap;
            GL.GenTextures(1, out textureId);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.Finish();
            bitmap.UnlockBits(data);
            return textureId;
        }
    }
}
