import static org.junit.Assert.*;

import org.junit.Test;


public class StudentTest {
	@Test
	public void testBestScore()
	{
		Student stud1 = new Student(90, 85);
		int answer = stud1.bestScore();
		assertEquals(answer, 90);
	}
}
