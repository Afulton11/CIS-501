class Program
{
	static void Main(string[] args)
	{
		Semester s = new Semester("Fall");
		Faculty t1 = new Faculty("Quirinus Quirrell"); //Defence Against the Dark Arts teacher at Hogwarts
		Faculty t2 = new Faculty("Filius Flitwick"); //Charms teacher at Hogwarts
		Course c1 = new Course() { title = "Advanced Black Arts", number = 9899 };
		Course c2 = new Course() { title = "Third Year Charms", number = 8499 };

		Console.WriteLine("Semester = [{0}]", s.GetName());
		Console.WriteLine("Faculty = [{0}, {1}]", t1.GetName(), t2.GetName());
		Console.WriteLine("Course = [{0}, {1}]", c1.title, c1.number);
		Console.WriteLine("Course = [{0}, {1}]", c2.title, c2.number);

		OnCampus section1 = new OnCampus(s, c1, t1, "B06", 50);
		Online section2 = new Online(s, c2, t2, "C03", 63);
		Console.WriteLine(section1.ToString());
		Console.WriteLine(section2.ToString());

		Console.ReadKey();
	}
}