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
        Economy = 1,
        MiddleClass = 2,
        Premium = 3,
        Luxury  = 4,
        Deluxury = 5
    }


    class Program
    {

        struct Furniture
        {
            public static int Current_ID = 0;

            public int Id;
            public string Name;
            public double Weight;
            public ClassFurniture classFurniture;
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

        static bool InputBool(string message) //проверка булевская
        {
            bool inputResult;
            bool b;
            do
            {
                Console.Write(message);
                inputResult = bool.TryParse(Console.ReadLine(), out b);
            } while (!inputResult);
            return b;

        }
        static double InputDouble(string message) //проверка double
        {
            bool inputResult;
            double number;

            do
            {
                Console.Write(message);
                inputResult = double.TryParse(Console.ReadLine(), out number);
            } while (!inputResult || number < 0);

            return number;
        }

        static string InputString(string message) //проверка на текст
        {
            Console.Write(message);
            return Console.ReadLine();
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

        static Furniture CreateFurniture(bool isNewId) //ввод элемента мебели
        {

            Furniture furniture;
            if (isNewId)
            {
                Furniture.Current_ID++;
                furniture.Id = Furniture.Current_ID;
            }
            else
            {
                furniture.Id = 0;
            }
            furniture.Name = InputString("Введите название мебели: ");
            furniture.Weight = InputDouble("Введите вес: ");
            furniture.classFurniture = (ClassFurniture)InputInt("Выберите класс мебели: \n 1. Эконом \n 2. Средний класс \n 3. Премиум \n 4. Люкс \n 5. ДеЛюкс \n");
            furniture.Rating = InputDouble("Введите рейтинг покупателей: ");

            return furniture;
        }

        /*static Furniture CreateEmptyFurniture()
        {
            Furniture furniture;
            furniture.Id = 0;
            furniture.Name = "";
            furniture.Weight = 0;
            furniture.classFurniture = 0;
            furniture.Rating = 0;
            return furniture;
        }*/

        static void PrintFurniture(Furniture furniture) //печать 1го элемента(любой)
        {
            Console.WriteLine("{0,-5}{1,-20}{2,-10}{3,-15}{4,5}",furniture.Id, furniture.Name, furniture.Weight, furniture.classFurniture, furniture.Rating);
        }

        static void PrintManyFurnitures(Furniture[] furnitures) //печать всех элементов(весь перечень)
        {
            Console.WriteLine("{0,-5}{1,-20}{2,-10}{3,-15}{4,-5}", "ИД", "Название", "Вес(кг)", "Класс мебели", "Рейтинг покупателей");

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


        static void PrintClassFurniture(ref Furniture furniture)
        { 
            
        int menuPoint = InputInt("Выберите позицию в меню: ");

            switch (menuPoint)
            {
                case 1:
                    {
                        Console.Write("Введите класс ");
                       int newClassFurniture = int.Parse(Console.ReadLine());
                       int classFurniture = ClassFurniture.Economy;
                    }
                    break;
            }

        }
            /*
           static int PrintClassFurniture(ref Furniture furniture) // выборка класса
            {
                ClassFurniture classFurniture;

                Console.WriteLine("Введите число от 1 до 5");
                int number = int.Parse(Console.ReadLine());

                if (number == 1)
                {
                    classFurniture = ClassFurniture.Economy;
                }
                else if (number == 2)
                {
                    classFurniture = ClassFurniture.MiddleClass;
                }
                else if (number == 3)
                {
                    classFurniture = ClassFurniture.Premium;
                }
                else if (number == 4)
                {
                    classFurniture = ClassFurniture.Luxury;
                }
                else if (number == 5)
                {
                    classFurniture = ClassFurniture.Deluxury;
                }
                return classFurniture;
            }
            */
            static void PrintManyFutnitureToFile(Furniture[] furnitures, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            writer.WriteLine("{0,-5}{1,-20}{2,-10}{3,-15}{4,-5}", "ИД", "Название", "Вес(кг)", "Класс мебели", "Рейтинг покупателей");

            if (furnitures == null)
            {
                writer.WriteLine("Таблица мебели пуста");
            }
            else if (furnitures.Length == 0)
            {
                writer.WriteLine("Таблица мебели пуста");
            }
            else
            {
                for (int i = 0; i < furnitures.Length; i++)
                {
                    writer.WriteLine("{0,-5}{1,-20}{2,-10}{3,-15}{4,5}", furnitures[i].Id, furnitures[i].Name, furnitures[i].Weight, furnitures[i].classFurniture, furnitures[i].Rating);
                }
            }
            writer.Close();
        }
        static void SaveManyFurnitureToFile(Furniture[] furnitures, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            writer.WriteLine(furnitures.Length);
            writer.WriteLine(Furniture.Current_ID);

            for (int i = 0; i < furnitures.Length; i++)
            {
                writer.WriteLine(furnitures[i].Id);
                writer.WriteLine(furnitures[i].Name);
                writer.WriteLine(furnitures[i].Weight);
                writer.WriteLine(furnitures[i].classFurniture);
                writer.WriteLine(furnitures[i].Rating);
            }

            writer.Close();
        }
        #endregion

        #region Основные функции

        static Furniture[] FindFurnituresFromMinToMaxWeigth(Furniture[] furnitures, double mixWeigth, double maxWeigth) //Поиск мебели от мин до макс веса
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
        static void SortFurnituresByWeigth(Furniture[] furnitures) //Соритировка по Весу
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

        static void SortFurnituresByRating(Furniture[] furnitures) //Соритировка по Рейтингу
        {
            Furniture temp;
            bool sort;
            int offset = 0;

            do
            {
                sort = true;

                for (int i = 0; i < furnitures.Length - 1 - offset; i++)
                {
                    if (furnitures[i + 1].Rating < furnitures[i].Rating)
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
        static void InMemu()
        {
            Console.WriteLine("1.Выберите класс");
        }
        static void PrintMenu() // Интерфейс меню    
        {
            Console.WriteLine("1. Добавление новой позиции");
            Console.WriteLine("2. Поиск мебели от минимального до максимального веса");
            Console.WriteLine("3. Сортировка мебели по весу");
            Console.WriteLine("4. Сортировка мебели по ретингу покупателей");
            Console.WriteLine("5. Добавление таблицы в файл .txt");
            Console.WriteLine("6. Сохранение таблицы в файл .txt");

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
                            Furniture addedFurniture = CreateFurniture(true);
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

                    case 3:
                        {
                            SortFurnituresByWeigth(furnitures);
                        }
                        break;

                    case 4:
                        {
                            SortFurnituresByRating(furnitures);
                        }
                        break;

                    case 5:
                        {
                            string fileName = InputString("Введите название файла: ");
                            PrintManyFutnitureToFile(furnitures, fileName);
                        }
                        break;

                    case 6:
                        {
                            string fileName = InputString("Введите название файла: ");
                            SaveManyFurnitureToFile(furnitures, fileName);
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