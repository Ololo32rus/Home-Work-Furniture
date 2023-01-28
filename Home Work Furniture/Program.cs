/*сделать предметную область "Предмет Мебели" с полями:
-ид - число целое
-название предмета мебели - строка
-вес кг - число дробное
-класс мебели (эконом средний люкс и тд - 4/5 классов) - Enum
-рейтинг у покупателей - число дробное

Функции
сделать расширяемый массив неограниченной длины с возможностями:
-добавление предмета мебели в конец массива
-вывод всех предметов мебели на экран
-вывод всех предметов мебели в файл
-сортировка предметов мебели по рейтингу
-вывод мебели с весом в диапазонет от мин до макс веса
*/


namespace StructFurnitureShop
{
    public enum ClassFurniture
    {
        Economy,
        MiddleClass,
        Premium,
        Luxury,
        Deluxury,
    }


    class Program
    {
        static int Current_ID = 0;
        struct Furniture
        {
            public int Id;
            public string Name;
            public double Weight;
            public string Class;
            public double Rating;

        }
        #region Вспомогательные методы
        static void ResizeArray(ref Furniture[] furnitures, int newLength) // перезаписываем/копируем массив (добавляем +1 ячейку)
        {
            int minLength = newLength > furnitures.Length ? furnitures.Length : newLength;

            Furniture[] newArray = new Furniture[newLength];

            for (int i = 0; i < minLength; i++)
            {
                newArray[i] = furnitures[i];
            }

            furnitures = newArray;

        }
        #endregion

        #region CRUD (создание, чтение, обновление, удаление)

        static void AddNewFurniture(ref Furniture[] furnitures, Furniture furniture) //добавление нового элемента в замен нулевого(пустого)
        {

            if (furnitures == null)
            {
                furnitures = new Furniture[1];
            }
            else
            {
                ResizeArray(ref furnitures, furnitures.Length + 1);
            }
            furnitures[furnitures.Length - 1] = furniture;
        }


        #endregion

        #region Вспомогательные методы

        static double GetMinWeigth(Furniture[] furnitures) // определение минимального веса мебели
        {
            double minWeigth = furnitures[0].Weight;

            for (int i = 0; i < furnitures.Length; i++)
            {
                if (furnitures[i].Weight < minWeigth)
                {
                    minWeigth = furnitures[i].Weight;
                }
            }
            return minWeigth;
        }

        static double GetMaxWeigth(Furniture[] furnitures) // определение максимального веса мебели
        {
            double maxWeigth = furnitures[0].Weight;

            for (int i = 0; i < furnitures.Length; i++)
            {
                if (furnitures[i].Weight > maxWeigth)
                {
                    maxWeigth = furnitures[i].Weight;
                }
            }
            return maxWeigth;
        }

        static Furniture CreateFurniture() //ввод элемента мебели
        {

            Furniture furniture;

            Current_ID++;
            furniture.Id = Current_ID;

            Console.Write("Введите название мебели: ");  //input создать
            furniture.Name = Console.ReadLine();

            Console.Write("Введите вес: ");
            furniture.Weight = double.Parse(Console.ReadLine());

            Console.Write("Выберите класс мебели: ");
            furniture.Class = Console.ReadLine();

            Console.Write("Введите рейтинг покупателей: ");
            furniture.Rating = double.Parse(Console.ReadLine());

            return furniture;
        }

        static void PrintFurniture(Furniture furniture) //печать 1го элемента(любой)
        {
            Console.WriteLine("{0,3}{1,20}{2,10}{3,10}{4,5},furniture.Id, furniture.Name, furniture.Weigth, furniture.Class, furniture.Rating");
        }

        static void PrintManyFurnitures(Furniture[] furnitures) //печать всех элементов(весь перечень)
        {
            Console.WriteLine("{0,3}{1,20}{2,10}{3,10}{4,5}", "ИД", "Название", "Вес(кг)", "Класс мебели", "Рейтинг покупателей");

            if (furnitures == null)
            {
                Console.WriteLine("Данных о мебели нет");
            }
            else
            {
                for (int i = 0; i < furnitures.Length; i++)
                {
                    PrintFurniture(furnitures[i]);
                }
            }

            Console.WriteLine("***********************");
        }
        /*
        static void PrintClassFurniture (Furniture furniture) // выборка класса
        {
        ClassFurniture classFurniture;

        if (Console.ReadLine() == 1)
        {
        classFurniture = ClassFurniture.Economy;
        }
        else if (Conosole.ReadLine() == 2)
        {
        classFurniture = ClassFurniture.MiddleClass;
        }
        else if (Conosole.ReadLine() == 3)
        {
        classFurniture = ClassFurniture.Premium;
        }
        else if (Conosole.ReadLine() == 4)
        {
        classFurniture
        Furniture.id
        furniture.Id
        = ClassFurniture.Luxury;
        }
        else if (Conosole.ReadLine() == 5)
        {
        classFurniture = ClassFurniture.Deluxury;
        }
        return classFurniture;
        }

        static void OutputClassFurniture(ClassFurniture classFurniture, Furniture[] furnitures) // вывод на экран класса мебели
        {
            switch (furnitures)
            {
                case 1:
                    {
                    classFurniture = ClassFurniture.Economy;
                        Console.WriteLine("Выберите класс эконом");
                        Console.ReadLine
                    }

                    break;


            }

                


        }
       */
        #endregion

        #region Основные функции

        static Furniture[] FindFurnituresFromMinToMaxWeigth(Furniture[] furnitures, double mixWeigth, double maxWeigth)
        {
            Furniture[] findedFurnitures = null;

            for (int i = 0; i < furnitures.Length; i++)
            {
                if (furnitures[i].Weight >= mixWeigth && furnitures[i].Weight <= maxWeigth)
                {
                    AddNewFurniture(ref findedFurnitures, furnitures[i]);
                }
            }
            return findedFurnitures;
        }

        #endregion

        #region Сортировка
        static void SortFurnituresByWeigth(Furniture[] furnitures)
        {
            Furniture temp;
            bool sort;
            int offset = 0;

            do
            {
                sort = true;

                for (int i = 0; i < furnitures.Length - 1 - offset; i++)
                {
                    if (furnitures[i + 1].Weight < furnitures[i].Weight)
                    {
                        temp = furnitures[i];
                        furnitures[i] = furnitures[i + 1];
                        furnitures[i + 1] = temp;

                        sort = false;
                    }
                }

            } while (!sort);
        }

        #endregion

        #region Методы работы с интерфейсом

        static void PrintMenu() // Интерфейс меню
        {
            Console.WriteLine("1. Добавление новой позиции");
            Console.WriteLine("2. Сортировка мебели от минимального до максимального веса");
            Console.WriteLine("0. Выход из программы");
        }

        static int InputInt(string message) //проверка ввода в меню на корректность
        {
            bool inputResult;
            int number;

            do
            {
                Console.Write("Введите пункт меню: ");
                inputResult = int.TryParse(Console.ReadLine(), out number);
            }
            while (!inputResult);

            return number;
        }

        #endregion

        // —----------------------------------------------------------------------—

        static void Main(string[] args) // основное тело программы
        {
            Furniture[] furnitures = null;
            bool runProgram = true;

            while (runProgram)
            {
                Console.Clear();
                PrintManyFurnitures(furnitures);

                PrintMenu();
                int menuPoint = InputInt("Выберите позицию в меню: ");

                switch (menuPoint)
                {
                    case 1:
                        {
                            Furniture addedFurniture = CreateFurniture();
                            AddNewFurniture(ref furnitures, addedFurniture);
                            continue;
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine($"Введите минимальный {GetMinWeigth(furnitures)} и максимальный {GetMaxWeigth(furnitures)} вес");

                            Console.Write("минимальный вес: ");
                            double minWeigth = double.Parse(Console.ReadLine());

                            Console.Write("максимальынй вес: ");
                            double maxWeigth = double.Parse(Console.ReadLine());

                            Furniture[] findedFurnitures = FindFurnituresFromMinToMaxWeigth(furnitures, minWeigth, maxWeigth);

                            PrintManyFurnitures(findedFurnitures);
                        }
                        break;

                    case 0:
                        {
                            Console.WriteLine("Программа будет закрыта");
                            Console.ReadKey();

                            runProgram = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        Console.ReadKey();
                        break;
                }

            }
            Console.ReadKey();
        }

    }
}