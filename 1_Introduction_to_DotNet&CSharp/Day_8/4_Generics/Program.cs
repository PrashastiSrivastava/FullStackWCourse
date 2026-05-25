namespace _4_Generics;

class Program {
    static void Main() {
        // Box with int (no boxing)
        Box<int> intBox = new Box<int>();
        intBox.Store(100);
        intBox.DisplayType();
        Console.WriteLine($"Value: {intBox.Retrieve()}\n");

        // Box with string
        Box<string> strBox = new Box<string>();
        strBox.Store("Raj");
        strBox.DisplayType();
        Console.WriteLine($"Value: {strBox.Retrieve()}\n");

        // Box with Student
        Box<Student> studentBox = new Box<Student>();
        studentBox.Store(new Student("Amit"));
        studentBox.DisplayType();
        Console.WriteLine($"Value: {studentBox.Retrieve()}\n");

        // Prove no boxing for int
        Console.WriteLine("=== No Boxing Demo ===");
        int num = 50;
        intBox.Store(num); // Direct storage, no object conversion
        Console.WriteLine($"Retrieved: {intBox.Retrieve()}");
    }
}