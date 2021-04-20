
public class Student {
	private int exam1, exam2;
	public Student(int ex1, int ex2)
	{
		exam1 = ex1;
		exam2 = ex2;
	}
	public int bestScore()
	{
		if(exam1 > exam2) return exam1;
			return exam2;
	}
	
}
