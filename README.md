# IGI
Irregular Grid Interpolator - интерполяция табличных данных

Версия 1.2.3 (май 2015г.)
Разработчик Смехов А.Н.

Данная программа предназначена для нахождения значений табличной функции двух переменных в узлах регулярной сетки на основе
известного набора точек. Исходный набор точек может быть задан как на регулярной равномерной сетке, так и на нерегулярной сетке.

Для интерполяции данных программа использует методы библиотеки ALGLIB (©Sergey Bochkanov, ALGLIB Project, www.alglib.net),
распространяемой по лицензии GNU/GPL (файл alglibnet2.dll). Для визуализации поверхности используется библиотека OpenGL, доступ к
которой производится через функции библиотеки OpenTK (файл OpenTK.dll).

Для работы программы требуется Microsoft .NET Framework версии 3.5 или выше.
