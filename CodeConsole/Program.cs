using TestDamary.CandyCrush;
using TestDamary.DragonHatch;
using TestDamary.OOP_Class_;


/*----------------------------------0.	Class (OOP) ---------------------------------------*/

//Vector pos = new Vector(0, 0);
//int hp = 100;
//int mp = 50;
//int level = 1;
//int power = 5;

//Charactor charactor = new Charactor(pos, hp, mp, level, power);
//X target = new X(50, 2);

//Console.WriteLine("Gia tri ban dau");
//Console.WriteLine($"Position: X = {charactor._position.X}, Y = {charactor._position.Y}\n HP: {charactor._hp}\n MP: {charactor._mp}\n Level: {charactor._level}\n Power: {charactor._power}");

//string continueAction;
//do
//{
//    Console.WriteLine("Nhap hanh dong: \n 1.Jump \n 2.Attack \n 3.GetHit \n 4.LevelUp");
//    int n = Convert.ToInt32(Console.ReadLine());

//    switch (n)
//    {
//        case 1:
//            charactor.Jump();
//            break;
//        case 2:
//            charactor.Attack(target);
//            break;
//        case 3:
//            charactor.GetHit(target.damage);
//            break;
//        case 4:
//            charactor.LevelUp(10, 5, 2);
//            break;

//        default:
//            Console.WriteLine("Hanh dong khong hop le");
//            break;
//    }

//    Console.WriteLine("Gia tri sau khi thuc hien hanh dong");
//    Console.WriteLine($"Position: X = {charactor._position.X}, Y = {charactor._position.Y}\n HP: {charactor._hp}\n MP: {charactor._mp}\n Level: {charactor._level}\n Power: {charactor._power}");

//    Console.WriteLine("Ban co muon thuc hien hanh dong khac khong? (Y/N)");
//    continueAction = Console.ReadLine().ToUpper();

//} while (continueAction == "Y");
//Console.ReadKey();

/*----------------------------------1.	Candy Match  ---------------------------------------*/

//int n ,m;
//do
//{
//    Console.Write("Nhap n (>= 4): ");
//    n = Convert.ToInt32(Console.ReadLine());
//}
//while (n < 4);

//do
//{
//    Console.Write("Nhap m (>= 4): ");
//    m = Convert.ToInt32(Console.ReadLine());
//}
//while (m < 4);


//string[] M = new string[n * m];

//Console.WriteLine("Nhập các phần tử của ma trận:");
//for (int i = 0; i < n * m; i++)
//{
//    M[i] = Console.ReadLine();
//}

//CandyMatch candyMatch = new CandyMatch();
//string[] candyMatrix = new string[]
//       {
//            "X", "T", "D", "L", "N",
//            "L", "X", "X", "C", "X",
//            "D", "X", "X", "D", "D",
//            "T", "X", "T", "D", "L",
//            "L", "C", "L", "D", "L"
//       };

// int rows = 5;
// int columns = 5;

//if (candyMatrix.Length != rows * columns)
//{
//    Console.WriteLine("Matrix size does not match the expected dimensions.");
//    return;
//}

//Dictionary<char, List<int>> validClusters = candyMatch.FindValidClusters(candyMatrix, rows, columns);

//if (validClusters.Count == 0)
//{
//    Console.WriteLine("No clusters found.");
//}
//else
//{
//    foreach (var pair in validClusters)
//    {
//        Console.WriteLine($"Candy type '{pair.Key}' has {pair.Value.Count} elements: {string.Join(",", pair.Value)}");
//    }
//}

/*--------------------------------- DragonHatch ----------------------------------------*/

DragonHatch dragonHatch = new DragonHatch();

int[,] matrix = new int[5, 5];
int count = 0;
List<int> midIndex = new List<int>();


for (int i = 0; i < 5; i++)
{
    for(int j = 0; j < 5; j++)
    {
        matrix[i, j] = count++;
    }
}


Console.WriteLine("Nhap cum thang");
int n = Convert.ToInt32(Console.ReadLine());
string[] A = new string[n];


for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Nhap cum thang {i + 1} (dinh dang [K];[index1, index2, ...]):");
    A[i] = Console.ReadLine();
}

foreach (string c in A)
{
    string[] part = c.Split(';');
    if(part.Length != 2)
    {
        Console.WriteLine("Dinh dang sai: ");
        continue;
    }

    string[] indices = part[1].Split(',');

    int[] intIndices = Array.ConvertAll(indices, int.Parse);

    int[] sortedIndices = dragonHatch.GetSortedIndices(matrix, intIndices);

   
    int midIndexValue = dragonHatch.GetMiddleIndex(sortedIndices);
    midIndex.Add(midIndexValue);
}

Console.WriteLine($"[{string.Join(",", midIndex)}]");





