{
    int[] numbers = { 7, 3, 5, 8, 2, 9, 4, 15, 6 };
    SortBySelection(numbers);
    Console.WriteLine("Sıralanmış dizi: " + string.Join(",", numbers));
}
/*
1. Adim: { 2, 3, 5, 8, 7, 9, 4, 15, 6}
2. Adim: { 2, 3, 5, 8, 7, 9, 4, 15, 6}
3. Adim: { 2, 3, 4, 8, 7, 9, 5, 15, 6}
4. Adim: { 2, 3, 4, 5, 7, 9, 8, 15, 6}
5. Adim: { 2, 3, 4, 5, 6, 9, 8, 15, 7}
6. Adim: { 2, 3, 4, 5, 6, 7, 8, 15, 9}
7. Adim: { 2, 3, 4, 5, 6, 7, 8, 15, 9}
8. Adim: { 2, 3, 4, 5, 6, 7, 8, 9, 15}
9. Adim: { 2, 3, 4, 5, 6, 7, 8, 9, 15}
Siralanmis dizi: 2,3,4,5,6,7,8,9,15
*/

// Her n kadar dönerken başka bir n kadar döndük bu'da Big O(N^2) yapar. Worst Case ve Maliyetli.
//Comprable koyma nedenimiz karşılaştırma yapacağımız içindir.
static void SortBySelection<T>(T[] array) where T : IComparable
{
    //Eleman başına işlem tekrarı
    for (int a = 0; a < array.Length; a++)
    {
        int min = a; //Varsayılan sayı
        for (int b = a + 1; b < array.Length; b++)
        {
            // Minimum olarak varsayılan sayıyla sonraki sayıları kıyasla ve başka bir minimum sayı görürsen yeni düşük sayıyı setle
            if (array[min].CompareTo(array[b]) > 0)
            {
                min = b;
            }
        }
        var tmp = array[a]; //Geçici olarak a elemanı sakla
        array[a] = array[min]; //En küçük sayıyı en büyük sayıyla değiştir
        array[min] = tmp; //Eski küçük sayının indeks değerini büyük sayıyla değiştir.

        Console.Write($"{a + 1}. Adım: {"{"} ");
        for (int k = 0; k < array.Length; k++)
        {
            Console.Write(array[k]);
            if (k < array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.Write($"{"}"}");
        Console.WriteLine();
    }
}