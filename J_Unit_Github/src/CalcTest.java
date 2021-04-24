import org.junit.After;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;

import static org.junit.Assert.*;

public class CalcTest {
	//
	private Calc calc;
	
	@Before
	public void setUp()
	{
		calc=  new Calc();
	}
	@After
	public void tearDown()
	{
		calc = null;
	}
	//7.5
	public int div(int num1, int num2)
	{
		if(num2==0)
			throw new ArithmeticException("div by zero");
		return num1/num2;
	}
	//7.6
	@Test(expected = ArithmeticException.class)
	public void testDiv()
	{
		int expected = calc.min(2,  0);
	}
	//7.7
	
	
	
	
	
	
	@Test
	public void testAdd()
	{
		Calc calc = new Calc();
		int num1 = 2;
		int num2 = 3;
		int expected = 5;
		assertEquals(expected, calc.add(num1 , num2));
	}
	@Ignore("Not ready to test")
	@Test
	public void testMin()
	{
		Calc calc = new Calc();
		int num1 = 2;
		int num2 = 3;
		int expected = 2;
		assertEquals(expected, calc.min(num1 , num2));
	}
}
