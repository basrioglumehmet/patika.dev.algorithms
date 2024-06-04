

{
    int[] numbers = { 22, 27, 16, 2, 18, 6 };

    /*
    * 22,27,16,2,18,6 Sırasız dizi
    * 22,16,27,2,18,6 27 ile 16 yer değişir
    * 16,22,27,2,18,6 16 ile 22 yer değişir (22 büyük)
    * 16,22,2,27,18,6 2 ile 27 yer değiştirir. (27 büyük)
    * 16,2,22,27,18,6 22 ile 2 yer değiştirir
    * 2,16,22,27,18,6 16 ile 2 yer değiştirir
    * 2,16,22,18,27,6 27 ile 18 yer değiştirir (27 büyük)
    * 2,16,18,22,27,6 22 ile 18 yer değiştirir
    * 2,16,18,22,6,27 6 ile 27 yer değiştrir ve bu 6'dan küçük eleman bulana kadar devam eder
    * 2,6,16,18,22,27 son hali olur.

    * Average case: Aradığımız sayının ortada olması
    * Worst case: Aradığımız sayının sonda olması
    * Best case: Aradığımız sayının dizinin en başında olması.

    * [22,27,16,2,18,6] -> Insertion Sort
    * Yukarı verilen dizinin sort türüne göre aşamalarını yazınız.
    * Big-O gösterimi: N kadar işlem için başka n kadar işlem yapılıyor. O(N^2) dominant
    * Time Complexity: Dizi sıralandıktan sonra 18 sayısı aşağıdaki case'lerden hangisinin kapsamına girer? Average Case çünkü aradığımız sayı dizinin ortasına gelmektedir. 
    */
    SortByInsertion(numbers);
    Console.WriteLine("Sıralanmış dizi: " + string.Join(",", numbers));
}
static void SortByInsertion<T>(T[] array) where T : IComparable<T>
{
    //Adım 1: Her zaman dizinin ikinci elemanından başlanır (i = 1)
    for (int i = 1; i < array.Length; i++)
    {
        // current: sıralamak istediğimiz mevcut eleman
        T current = array[i];
        // before: current elemanının bir önceki indeksi
        int before = i - 1;
        /*
         * CompareTo metodu şu sonuçları verir:
         * Negatif bir sayı: Eğer current, array[before]'dan küçükse.
         * Sıfır: Eğer current, array[before]'a eşitse.
         * Pozitif bir sayı: Eğer current, array[before]'dan büyükse.
         */
        //Adım 2: current elemanı, solundaki elemanlarla karşılaştırılır
        while (before >= 0 && array[before].CompareTo(current) > 0)
        {
            //Adım 3: Eğer current, array[before]'dan küçükse, array[before]'ı bir sağa kaydırır
            array[before + 1] = array[before];
            //Adım 4: Bir sonraki sol elemanı kontrol etmek için before indeksini bir azaltır
            before--;
        }
        //Adım 5: current elemanını doğru konumuna yerleştirir
        array[before + 1] = current;
    }
}