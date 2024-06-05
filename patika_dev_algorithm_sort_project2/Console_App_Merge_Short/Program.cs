{
    // Proje 2
    // [16,21,11,8,12,22] -> Merge Sort
    // Yukarıdaki dizinin sıralama türüne göre aşamalarını yazınız.
    // Big-O gösterimini yazınız. O(nlogn)
    int[] unshorted = { 16, 21, 11, 8, 12, 22 };
    // Diziyi Merge Sort algoritması ile sıralıyoruz
    SortByMerge(unshorted);
    // Sıralanmış diziyi ekrana yazdırıyoruz
    Console.WriteLine(string.Join(",", unshorted));
}
static void SortByMerge<T>(T[] array) where T : IComparable<T>
{
    // Eğer dizinin uzunluğu 1 veya daha az ise, zaten sıralıdır
    if (array.Length <= 1) return;
    // Dizinin ortasını buluyoruz
    int middle = array.Length / 2;
    // Sol yarısını ve sağ yarısını oluşturmak için iki yeni dizi oluşturuyoruz
    T[] leftArray = new T[middle];
    T[] rightArray = new T[array.Length - middle];
    // Diziyi ikiye ayırmak için bir sayaç kullanıyoruz
    int i = 0;
    int j = 0;
    // Diziyi ikiye ayırıyoruz: sol ve sağ
    for (; i < array.Length; i++)
    {
        // Ortadan sola doğru elemanları kopyalıyoruz
        if (i < middle)
        {
            leftArray[i] = array[i];
        }
        // Ortadan sağa doğru elemanları kopyalıyoruz
        else
        {
            rightArray[j] = array[i];
            j++;
        }
    }
    // Sol ve sağ yarıları ayrı ayrı sıralıyoruz
    SortByMerge(leftArray);
    SortByMerge(rightArray);
    // Sıralı yarıları birleştiriyoruz
    Merge(leftArray, rightArray, array);
}
static void Merge<T>(T[] left, T[] right, T[] originalArray) where T : IComparable<T>
{
    int leftSize = originalArray.Length / 2;
    int rightSize = originalArray.Length - leftSize;
    // İndeksler
    int i = 0; // originalArray için
    int l = 0; // left için
    int r = 0; // right için
    // Hem sol hem de sağ dizide elemanlar olduğu sürece karşılaştırma yapıyoruz
    while (l < leftSize && r < rightSize)
    {
        // Sol dizideki eleman sağ dizideki elemana eşit veya küçükse
        if (left[l].CompareTo(right[r]) <= 0)
        {
            originalArray[i] = left[l]; // Sol diziden eleman al
            i++;
            l++;
        }
        // Sağ dizideki eleman sol dizidekinden küçükse
        else
        {
            originalArray[i] = right[r]; // Sağ diziden eleman al
            i++;
            r++;
        }
    }
    // Eğer sol dizide kalan elemanlar varsa, onları da ekliyoruz
    while (l < leftSize)
    {
        originalArray[i] = left[l];
        i++;
        l++;
    }
    // Eğer sağ dizide kalan elemanlar varsa, onları da ekliyoruz
    while (r < rightSize)
    {
        originalArray[i] = right[r];
        i++;
        r++;
    }
}