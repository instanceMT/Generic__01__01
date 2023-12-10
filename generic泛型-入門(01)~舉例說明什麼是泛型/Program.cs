namespace generic泛型_入門_01__舉例說明什麼是泛型
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 宣告泛型物件 
            // 在 MyClass 類別內， Tp1 為 int, Tp2 是 float 的意思 
            var obj = new MyClass<int,float>();
            #endregion

            #region 呼叫非泛型方法
            //obj.WriteValue(12.1,13.4f); // 因為12.1 不是 int, 所以這樣不行
            obj.WriteValue12(12,13.4f);
            #endregion

            #region 呼叫實體泛型方法
            obj.WriteValue3<double,int>(12.234,1);// obj.WriteValue3<double,int>(12.234,1.2);  1.2 不是 int, 不可以
            obj.WriteValue3(5.333333,1.2f);  // 這樣也可以
            #endregion

            #region 呼叫靜態泛型方法
            // MyClass.WriteValue4<double>(123)  這樣不可以
            // MyClass<,>.WriteValue4<double>(123); 這樣也不可以
            MyClass<int,int>.WriteValue4<double>(123);
            
            MyClass2.WriteValue4(223.222);
            MyClass2.WriteValue4<int>(223);
            #endregion
            Console.ReadKey();
        }
    }

    // Tp1、Tp2 是兩個泛型的型別變數
    // 型別變數名稱通常為大寫開始，命名儘量符合用途
    public class MyClass<Tp1,Tp2>
    {
        public MyClass()
        {

        }
        public void WriteValue12(Tp1 tp1,Tp2 tp2)
        {
            Console.WriteLine($"泛型資料1：{tp1.ToString()},泛型資料2：{tp2.ToString()} "); 
        }

        // 泛型方法(實體方法)
        public void WriteValue3<Tpa,Tpb>(Tpa a,Tpb b)
        {
            Console.WriteLine($"泛型資料1：{a.ToString()},泛型資料2：{b.ToString()} ");
        }

        // 泛型方法(靜態方法)
        public static void WriteValue4<Tp>(Tp t)
        {
            Console.WriteLine($"泛型資料：{t}");
        }
    }

    public class MyClass2
    {
        // 泛型方法(靜態方法)
        public static void WriteValue4<Tp>(Tp t)
        {
            Console.WriteLine($"泛型資料：{t}");
        }
    }

     
}

