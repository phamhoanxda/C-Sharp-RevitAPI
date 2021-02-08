using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    class Program
    {
        // ********* KIỂU DỮ LIỆU TRONG C# ************
        static void Main(string[] args)
        {
            int a = 1;
            double b = a + 0.5;
            // int c = b + 2;
        }

        //Ví dụ 01
        static void Main1(string[] args)
        {
            // Kiểu số nguyên
            byte BienByte = 10;
            short BienShort = 10;
            int BienInt = 10;
            long BienLong = 10;

            // Kiểu số thực
            float BienFloat = 10.9f; // Giá trị của biến kiểu float phải có hậu tố f hoặc F.
            double BienDouble = 10.9; // Giá trị của biến kiểu double không cần hậu tố.
            decimal BienDecimal = 10.9m; // Giá trị của biến kiểu decimal phải có hậu tố m.

            // Kiểu ký tự và kiểu chuỗi
            char BienChar = 'T'; // Giá trị của biến kiểu ký tự nằm trong cặp dấu '' (nháy đơn).
            string BienString = "TT Design"; // Giá trị của biến kiểu chuỗi nằm trong cặp dấu ""(nháy kép).

            Console.ReadKey();
        }

        // Ví dụ 02
        static void Main2(string[] args)
        {
            // Kiểu số nguyên
            byte BienByte = 3;
            short BienShort = 9;
            int BienInt = 10;
            long BienLong = 0;

            BienLong = BienByte; // BienLong có kiểu dữ liệu lớn hơn BienByte nên giá trị BienByte có thể gán qua cho BienLong
            Console.WriteLine(" BienLong = " + BienLong);

            BienLong = BienInt; // tương tự như trên
            Console.WriteLine(" BienLong = {0}", BienLong);

            BienShort = BienByte; // tương tự như trên
            Console.WriteLine(" BienShort = " + BienShort);

            BienInt = BienShort; // tương tự như trên
            Console.WriteLine(" BienInt = " + BienInt);

            Console.ReadKey();
        }

        // Ví dụ 03: Những lỗi cần lưu ý.==> Y/C mọi người fix lỗi
        /*
        static void Main3(string[] args)
        {
            int a;
            Console.WriteLine(" a = " + a);

            int b = 10.9;

            byte c = 1093;

            string d = 'K';
           
            long e = null;

            long? f = null;

            int g = 10;
            byte h = g;

            string t = "TT Design";
            Console.WriteLine(" t = " + T);

            Console.ReadKey();
        }
        */

        /* CHỮA BÀI
        static void Main3(string[] args)
        {
            int a;
            Console.WriteLine(" a = " + a); 
            // Lỗi vì biến a không thể sử dụng khi chưa có giá trị.

            int b = 10.9; 
            // Lỗi vì b là biến kiểu số nguyên nên không thể nhận giá trị ngoài số nguyên.

            byte c = 1093; 
            // Lỗi vì c là biến kiểu byte mà kiểu byte có miền giá trị từ -128 đến 127 nên không thể nhận giá ngoài vùng này được.

            string d = 'K'; 
            // Lỗi vì không thể gán giá trị ký tự vào biến kiểu chuỗi được mặc dù chuỗi có thể hiểu là tập hợp nhiều ký tự. 
            //Có thể sửa bẳng cặp dấu "" thay vì ''.
            
            long e = null; 
            // Lỗi vì không thể gán null cho biến kiểu long, int, byte, 

            long? f = null; 
            // Cách khắc phục là thêm dấu ? vào sau kiểu dữ liệu.Lúc này kiểu dữ liệu của f là long?
            
            int g = 10;
            byte h = g; 
            // Lỗi vì giá trị của biến có kiểu dữ liệu lớn hơn không thể gán cho biến có kiểu dữ liệu nhỏ hơn
            //mặc dù trong trường hợp này ta thấy số 10 đều có thể gán cho 2 biến.
            
            string t = "TT Design";
            Console.WriteLine(" t = " + T); 
            // Lỗi vì phía trên khai báo biến t còn khi sử dụng là biến T
            //(C# có phân biệt chữ hoa, thường cần lưu ý để tránh gặp lỗi)
            
            Console.ReadKey();
        }
        */

        // ********* TOÁN TỬ TRONG C# ************
        //VD 01
        static void Main4(string[] args)
        {
            int a, b, c;
            a = b = (c = 9) + 1;
            // khởi tạo giá trị: a = 10, b = 10, c = 9

            a += b;
            // tương đương a = a + b

            b = c++; // thực hiện gán giá trị c cho biến b sau đó thực hiện c = c + 1

            --c; // thực hiện c = c - 1

            Console.WriteLine(" a = {0}, b = {1}, c = {2}", a, b, c);
            Console.ReadKey();
        }

        //VD02
        static void Main5(string[] args)
        {
            string strSoNguyen; // Biến chứa dữ liệu nhập vào từ bàn phím
            int SoNguyen; // Biến chứa số nhập vào từ bàn phím
            string KetQua; // Biến chứa kết quả kiểm tra số vừa nhập là chẵn hay lẻ

            strSoNguyen = Console.ReadLine();
            // Đọc dữ liệu nhập vào từ bàn phím (dữ liệu này ở dạng chuỗi) sau đó gán giá trị vào biến strSoNguyen

            SoNguyen = Int32.Parse(strSoNguyen);
            // Ép kiểu dữ liệu vừa nhập vào (dạng chuỗi) sang dạng số rồi gán giá trị vào biến SoNguyen

            KetQua = (SoNguyen % 2 == 0) ? "so chan" : "so le";
            // Sử dụng toán tử 3 ngôi để kiểm tra số chẵn lẻ

            Console.WriteLine("{0} la {1}", SoNguyen, KetQua);
            // In kết quả ra màn hình
            Console.ReadKey();
        }

        // ******************* ÉP KIỂU TRONG C# ************
        //Ep ngầm định
        static void Main6(string[] args)
        {
            int intValue = 10;
            long longValue = intValue;
            /* Chuyển kiểu ngầm định vì kiểu long có miền giá trị
               lớn hơn kiểu int nên có thể chuyển từ int sang long.*/

            float floatValue = 10.9f;
            double doubleValue = floatValue;
            /* Tương tự vì kiểu double có miền giá trị lớn
                hơn kiểu float nên có thể chuyển từ float sang double.*/
        }

        //ép tường minh
        static void Main7(string[] args)
        {
            double d = 2 / 3;
            // kết quả ra 0 vì 2 và 3 đều là số nguyên nên thực hiện 2 chia lấy phần nguyên với 3 được 0

            double k = (double)2 / 3;
            // Ép kiểu số 2 từ kiểu nguyên sang kiểu số thực. Như vậy kết quả phép chia sẽ ra số thực

            double t = 1.0 * 2 / 3;
            // Thực hiện nhân 1.0 với 2 mục đích để biến số 2 (sốnguyên) thành 2.0(số thực)

            Console.WriteLine(" d = {0} \n k = {1} \n t = {2}", d, k, t);
        }

        //Ep theo phương thức và lớp hỗ trợ sẵn

        //PARSE()
        static void Main8(string[] args)
        {
            string stringValue = "10";
            int intValue = int.Parse(stringValue);
            // Chuyển chuỗi stringValue sang kiểu int và lưu giá trị vào biến intValue - Kết quả intValue = 10

            double TTDesign = double.Parse("10.9");
            // Chuyển chuỗi giá trị hằng "10.9" sang kiểu int và lưu giá trị vào biến TTDesign - Kết quả TTDesign = 10.9
        }

        //TRYPARSE()
        static void Main9(string[] args)
        {
            int Result; // Biến chứa giá trị kết quả khi ép kiểu thành công
            bool isSuccess; // Biến kiểm tra việc ép kiểu có thành công hay không

            string Data1 = "10", Data2 = "TTDesign"; // Dữ liệu cần ép kiểu

            isSuccess = int.TryParse(Data1, out Result);
            // Thử ép kiểu Data1 về int nếu thành công thì Result 
            //sẽ chứa giá trị kết quả ép kiểu và isSuccess sẽ mang giá trị true.
            // Ngược lại Result sẽ mang giá trị 0 và isSuccess mang giá trị false

            Console.Write(isSuccess == true ? " Success !" : " Failed !");
            // Sử dụng toán tử 3 ngôi để in ra màn hình việc ép kiểu đã thành công hay thất bại.

            Console.WriteLine(" Result = " + Result); // In giá trị Result ra màn hình

            isSuccess = int.TryParse(Data2, out Result); // Tương tự như trên nhưng thao tác với Data2
            Console.Write(isSuccess == true ? " Success !" : " Failed !"); // Tương tự như trên

            Console.WriteLine(" Result = " + Result); // Tương tự như trên
        }

        static void Main10(string[] args)
        {
            int A, B; // Biến chứa giá trị 2 số vừa nhập vào (kiểu số)
            int Tong, Hieu, Tich; // Biến chứa kết quả tổng, hiệu, tích
            double Thuong; // Vì phép chia có thể cho ra số thập phân nên dùng biến  kiểu double để chứa nó.
            string strA, strB; // Biến chứa giá trị 2 số nhập vào từ bàn phím (kiểu chuỗi)

            Console.WriteLine(" **************************************************");
            Console.WriteLine(" *  * ");
            Console.WriteLine(" * Chuong trinh tinh tong, hieu, tich, thuong *");
            Console.WriteLine(" * * ");
            Console.WriteLine(" **************************************************");
            
            Console.Write("\n Moi ban nhap so A: ");
            strA = Console.ReadLine(); // Nhận giá trị nhập vào từ bàn phím cho số A

            Console.Write(" Moi ban nhap so B: ");
            strB = Console.ReadLine(); // Nhận giá trị nhập vào từ bàn phím cho số B

            A = int.Parse(strA); // Ép kiểu giá trị nhập vào từ kiễu chuỗi sang kiểu số nguyên, sử dụng phương thức Parse()
            B = int.Parse(strB); // Tương tự

            Tong = A + B;
            Hieu = A - B;
            Tich = A * B;
            Thuong = (double)A / B; 
            // Ép kiểu số A về số thập phân để phép chia cho ra số thập phân

            Console.WriteLine(" Tong = " + Tong);
            Console.WriteLine(" Hieu = " + Hieu);
            Console.WriteLine(" Tich = " + Tich);
            Console.WriteLine(" Thuong = " + Thuong);
            Console.ReadKey();
        }
    }
}
