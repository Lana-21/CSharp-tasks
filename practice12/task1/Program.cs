using ConsoleApp12List.models;
using ConsoleApp4List.services;
using ConsoleApp4List.utils;
using System.Text;
using static System.Console;

OutputEncoding = Encoding.UTF8;
List<Employee> employees = EmployeeGen.GenEmployees(10);
ServiceListEmployee serviceList = new(employees);
int choise = 0;
string menu = """
    Оберіть операцію:
0. Вихід
1. Додати співробітника
2. Видалити співробітника
3. Показати список співробітників
4. Змінити інформацію про співробітника
5. Пошук співробітників
6. Сортування співробітників
""";
do
{
    Clear();
    WriteLine(menu);
    Write("\nВаш вибір: ");
    if (!int.TryParse(ReadLine(), out choise))
    {
        WriteLine("Невірний формат вводу. Натисніть будь-яку клавішу");
        ReadKey();
        continue;
    }
    if (choise == 0) break;
    switch (choise)
    {
        case 1:
            {
                serviceList.AddEmployee(new(
                    EmployeeGen.GenFirstName(),
                    EmployeeGen.GenLastName(),
                    EmployeeGen.GenPosition(),
                    EmployeeGen.GenWages(),
                    EmployeeGen.GenEmail()
                ));
                WriteLine("\nСпівробітника успішно додано!");
                break;
            }
        case 2:
            {
                serviceList.ShowList();
                WriteLine("\nОберіть номер співробітника для видалення:");
                if (int.TryParse(ReadLine(), out int delIndex))
                {
                    WriteLine(serviceList.RemoveEmployee(delIndex - 1));
                }
                else WriteLine("Невірний формат номера.");
                break;
            }
        case 3:
            {
                WriteLine("Список співробітників:\n");
                serviceList.ShowList();
                break;
            }
        case 4:
            {
                serviceList.ShowList();
                WriteLine("\nВведіть номер співробітника, якого хочете оновити:");
                if (int.TryParse(ReadLine(), out int index))
                {
                    var updatedEmp = EmployeeGen.GenEmployee();
                    if (serviceList.UpdateEmployee(index - 1, updatedEmp))
                    {
                        WriteLine($"\nСпівробітника успішно оновлено на:\n{updatedEmp}");
                    }
                    else WriteLine("Помилка: невірний індекс співробітника.");
                }
                else WriteLine("Невірний формат номера.");
                break;
            }
        case 5:
            {
                WriteLine("\nОберіть критерій пошуку:");
                WriteLine("1. За прізвищем");
                WriteLine("2. За посадою");
                string searchType = ReadLine();
                List<Employee> searchResults = new();
                if (searchType == "1")
                {
                    Write("Введіть прізвище для пошуку: ");
                    string lastName = ReadLine();
                    searchResults = serviceList.SearchByLastName(lastName);
                }
                else if (searchType == "2")
                {
                    Write("Введіть посаду для пошуку: ");
                    string position = ReadLine();
                    searchResults = serviceList.SearchByPosition(position);
                }
                WriteLine($"\nЗнайдено співробітників: {searchResults.Count}");
                int i = 0;
                foreach (var emp in searchResults)
                {
                    WriteLine($"{++i}. {emp}");
                }
                break;
            }
        case 6:
            {
                WriteLine("\nОберіть критерій сортування:");
                WriteLine("1. За прізвищем");
                WriteLine("2. За ім'ям");
                WriteLine("3. За посадою");
                WriteLine("4. За зарплатою");
                string sortType = ReadLine();
                switch (sortType)
                {
                    case "1": serviceList.SortByLastName(); break;
                    case "2": serviceList.SortByFirstName(); break;
                    case "3": serviceList.SortByPosition(); break;
                    case "4": serviceList.SortByWages(); break;
                    default: WriteLine("Невірний вибір сортування."); break;
                }
                WriteLine("\nСписок успішно відсортовано!");
                serviceList.ShowList();
                break;
            }
        default:
            break;
    }
    ReadKey();
} while (true);
