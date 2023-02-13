using static System.Console;
//TASK_1 Two matrix
#if false
int[] A = new int[5];
WriteLine("Enter 5 integer number for A array: "); 
for (int i =0; i<5; i++)
{
   int.TryParse(ReadLine(), out A[i]); //or Convert.ToInt32 (string) or int32.Parse(string) only for String (endone)
}
Write("A array: \n");  
foreach (int i in A) Write($"{i}\t");//foreach only for read
Write("\n"); 
Random rand = new Random();
double[,] B = new double[3, 4]; 
double[,] Bcopy = new double[3, 4]; 
   for (int i=0;i < 3; i++){
    for (int j = 0; j < 4; j++)
    {
            B[i, j] = rand.Next(7); 
    }
   }

double _maxB = B[0,0];
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if (B[i,j]>_maxB) _maxB = B[i,j];
    }
}
WriteLine ($"Maximal element in A: {A.Max()}"); 
WriteLine ($"Sum of elements in A: {A.Sum()}");
int _multA = 1;
int _sumEvenA = 0; 
for (int i=0; i<5; i++)
{
    if (A[i]%2==0) _sumEvenA+=A[i];
}
WriteLine ($"Sum of Even elements in A: {_sumEvenA}");
foreach (int i in A) _multA *= i; 
WriteLine ($"Multiplication of elements in A: {_multA}\n"); 

Write("B array: \n");  
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Write ($"{B[i, j]}\t");
    }
    Write("\n"); 
}
double _sumOddColB = 0; 
double _sumB = 0;
double _multB = 1;
foreach (double b in B) _sumB += b; 
foreach (double b in B) _multB *= b;
for (int i = 0; i < 3; i++)
{
    for(int j = 0; j < 4; j++)
    {
        if (j%2!=0) _sumOddColB+=B[i,j];
    }
}
WriteLine ($"Maximal element in B: {_maxB}"); 
WriteLine ($"Sum of elements in B: {_sumB}"); 
WriteLine ($"Multiplication of elements in B: {_multB}"); 
WriteLine ($"Sum of elements in Odd column in B: {_sumOddColB}"); 
//Array.Sort(A);//work only for 1dimension Array
//foreach (int i in A) Write($"{i}\t");
//B.CopyTo(Bcopy,0);
#endif
//TASK_2 Sum in array between min/max elements
#if false
int[,] arr = new int[5,5];
Random r = new Random();
int _max= arr[0,0];
int _min = arr[0,0];
//foreach (int i in arr) i = r.Next(-100,100);DO NOT WORK TO WRITE!!!
for (int i = 0; i < 5; i++)
{
    for (int j=0; j < 5; j++)
    {
    arr[i,j] = r.Next(-100, 100);//random significants
    }
}
int _minCol = 0; int _minRow = 0; int _maxCol = 0; int _maxRow = 0; //indexes of min max elements

for (int i = 0; i < 5; i++)//find min max elements
{
    for (int j=0; j < 5; j++)
    {
        if (arr[i,j]>_max)
        {
        _max = arr[i,j];
            _maxRow = i; _maxCol = j;
        }
        if (arr[i,j]<_min)
        {
        _min = arr[i,j];
            _minRow = i; _minCol = j;
        }
    }
}
//WriteLine($"{ arr.Rank}, {arr.Length}"); 
for (int i=0; i<5; i++)//Print arr
{
 for(int j=0; j<5; j++)
    {
        Write("{0}\t", arr[i,j]);
    }
    WriteLine(); 
}
WriteLine ($"Indexes MinElement: {_minRow}\t {_minCol}\t, MaxElement: {_maxRow}\t {_maxCol}");
bool minBeforemax = true;
if (_maxRow < _minRow || _maxRow == _minRow && _maxCol < _minCol) minBeforemax = false;//who is the first min or max?
if (!minBeforemax)//change indexes if it's nessesary
{
    int buf = _minRow; _minRow = _maxRow; _maxRow = buf;
    buf = _minCol; _minCol = _maxCol; _maxCol = buf; 
}
int sumBetweenMinMax = 0;

for (int i = _minRow; i <= _maxRow; i++)//Sum between elements
{
    if (i == _minRow && i == _maxRow)//min & max in one Row
    {
        for (int j = _minCol + 1; j < _maxCol; j++)
        {
            sumBetweenMinMax += arr[i, j];
        }
    }
    else if (i == _minRow && i != _maxRow)//max in the another Row. Sum only in the row where the min is
    {
        for (int j = _minCol + 1; j < 5; j++)
        {
            sumBetweenMinMax += arr[i, j];
        }
    }
    else if (i == _maxRow)//max in another Row, sum only in the row where the max is
    {
        for (int j = 0; j < _maxCol; j++)
        {
            sumBetweenMinMax += arr[i, j];
        }
    }
    else                //sum in the all cols between min & max where none min nor max
    {
        for (int j = 0; j < 5; j++)
        {
            sumBetweenMinMax += arr[i, j];
        }
    }
}
WriteLine ($"Max significance is {_max}\t Min significance is {_min}");
WriteLine($"Sum between Min and Max elements is: {sumBetweenMinMax}"); 
//for (int i=0; i<25; i++)  Write(*(arr + i)); WHY NOT WORKING?
#endif
//TASK_3 Caesar cipher

for (int i = 0; i < 256; i++) Write($"{i} - {(char)i}\t");//ASCII tab
WriteLine("\nEnter a string: "); 
String str =ReadLine();
WriteLine("\nEnter a key for cipher: ");
String Key = ReadLine(); int key = Convert.ToInt32(Key);
if (key > 26) key = key % 26; 
char [] strChar = str.ToCharArray();
int []  strInt = new int [strChar.Length];
    //Convert.ToInt32(strChar)
for (int i = 0; i < strChar.Length; i++)
{
    strInt[i] = Convert.ToInt32(strChar[i]); 
}
for (int i = 0; i < strChar.Length; i++)
{
    if (strInt[i] < 65 || strInt[i] > 122 || strInt[i] > 90 && strInt[i] < 97) continue; 

    if (strInt[i] > 65 && strInt[i]  < 90 && (strInt[i]+key)>90||
        strInt[i] > 97 && strInt[i] < 122 && (strInt[i] + key) > 122)
    {
        strInt[i] = strInt[i]+key - 26;
    }
    else strInt[i] += key;
}
for (int i=0; i < strInt.Length; i++)
{
    strChar[i] = (char)strInt[i]; 
}
foreach (char c in strChar) Write($"{c}");

#if true

#endif