Console.WriteLine("Hello, World!");



#region Ders1

//X();
//Y();

//Console.ReadLine();
////// Thread Nedir ? => delegate yapılanması ile tanımlamasını gerçekleştiririz.
//// method neyse thread de odur.
//// yazılım ayağa kalkarsa main thread ile ayağa kalkar. MAIN THREAD
//// MAİN THREAD DIŞINDAKİLER WORKER THREAD OLUR.
//// THREAD İÇERİSİNDE İŞLEMLERİMİZİ YAPARIZ ÖRNEĞİN VERİ TABANINDAN PERSONEL BİLGİLERİNİ ÇEKİYORUZ
//// BU THREAD BELLEĞE YÜKLENDİĞİ ANDA PROCESS HALİNE GETİRİLİR.
//// PROCESSLER 1 DEN FAZLA CPU KULLANABİLİR FAKAT THREADLER 1 CPU KULLANIR.

////// ASENKRON VE SENKRON KAVRAMLARI NEDİR ?
//// ASENKRON => Bir işlem sürerken diğer işlemlerin devam etmesi Mail gibi
//// SENKRON => Bir işlem sürerken diğer işlemlerin beklemesi Telefon konuşması gibi 


//// task ile thread arasındaki farklar nedir ? 
//// task => .net 4.0 ile gelmiştir. task ile thread arasındaki farklar şunlardır.
//// task => threadlerin üzerine inşa edilmiştir. daha performanslıdır.


//async void X()
//{
//   await Task.Run(() =>
//    {
//        for (int i = 1; i <= 1000; i++)
//            Console.WriteLine("X => " + i);
//    });

//}

//async void Y()
//{
//   await Task.Run(() =>
//    {
//        for (int i = 1; i <= 1000; i++)
//            Console.WriteLine("Y => " + i);
//    });

//}


#endregion

#region Ders2

//// Thread Sınıfı Nedir ? 
//Thread thread = new Thread(() =>
//{
//    for (int i = 1; i <= 1000; i++)
//        Console.WriteLine("X => " + i);
//});

//thread.Start();
//for (int i = 1; i <= 1000; i++)
//    Console.WriteLine("Y => " + i);

//// Thread ID Nedir ? 
//Console.WriteLine("Main Thread ID : " + Thread.CurrentThread.ManagedThreadId);
//Thread thread = new Thread(() =>
//{
//    Console.WriteLine("Worker Thread ID : " + Thread.CurrentThread.ManagedThreadId);
//});
//thread.Start();

//// IsBackground Nedir ?

//int i = 10;
//Thread thread = new Thread(() =>
//{
//    while (i > 0)
//    {
//        i--;
//        Console.WriteLine("X => " + i);
//        Thread.Sleep(1000);
//    }
//    Console.WriteLine("WORKER Thread Bitti");  

//});
////thread.IsBackground = true; // Main thread bittiğinde worker thread de biter.
//thread.IsBackground = false;
//thread.Start();

// ThreadState Nedir ?
//Thread thread = new Thread(() =>
//{
//    for (int i = 1; i <= 1000; i++)
//        Console.WriteLine("X => " + i);
//});
//var state = thread.ThreadState;
//Console.WriteLine(state);

//// Locking Nedir ? 
//// multithread zamanı iki farklı threadin aynı kaynağa erişim sağlamak istediğimizde race condition oluşur.
//// threadler arası locking yaparak bu durumu engelleyebiliriz.

//object _locking = new();
//int i = 0;
//Thread thread1 = new Thread(() =>
//{
//    lock (_locking)   
//    {
//        while (i < 10)
//        {
//            i++;
//            Console.WriteLine("Thread1 => " + i);
//        }

//    }
//});

//Thread thread2 = new Thread(() =>
//{
//    lock (_locking)
//    {
//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine("Thread2 => " + i);
//        }
//    }

//});
//thread1.Start();
//thread2.Start();

//// Sleep Nedir ?


//// Join Nedir ? 
// bir threadin başka bir threadin işleminin bitmesini beklemesi için kullanılır.
// threadler arası senkron davranış sağlar
// özellikle bir threadin bitip başka bir threadin çalışmasını istediğimiz zaman kullanılırız.

//int i = 0;
//Thread thread1 = new Thread(() =>
//{

//        while (i < 10)
//        {
//            i++;
//            Console.WriteLine("Thread1 => " + i);
//        }


//});

//Thread thread2 = new Thread(() =>
//{

//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine("Thread2 => " + i);
//        }


//});
//thread1.Start();
//thread1.Join(); // joinlenen thread bitene kadar sıradakini bekletir
//thread2.Start();





//// Thread Canceling Nedir ?


//Thread thread = new Thread((cancellationToken) =>
//{
//    var cancel = (CancellationTokenSource)cancellationToken;
//    while (true)
//    {
//        if (cancel.IsCancellationRequested) break;
//        Console.WriteLine("Hello, World!");
//    }
//    Console.WriteLine("TAMAMLANDI");
//});

//CancellationTokenSource cancellationToken = new CancellationTokenSource();
//thread.Start(cancellationToken);
//Thread.Sleep(2000);
//cancellationToken.Cancel();


//// Interrupt Nedir ?

//Thread thread = new Thread(() =>
//{
//    try
//    {
//        Console.WriteLine("Thread Başladı");
//        Thread.Sleep(10000);

//    }
//    catch (ThreadInterruptedException e)
//    {
//        Console.WriteLine("Thread Kesildi");
//    }
//});
//thread.Start();
//thread.Interrupt();



#endregion

#region Ders3MutexMonitor

////Spinning Nedir ? 

//bool threadCondition1 = true;
//bool threadCondition2 = false;

//Thread thread1 = new Thread(() =>
//{
//    while (true)
//    {
//        if (threadCondition1)
//        {
//            for (int i = 1; i <= 10; i++)
//                Console.WriteLine("Thread 1 => " + i);
                
//            threadCondition1 = false;
//            threadCondition2 = true;
//        }

//    }
    
//});

//Thread thread2 = new Thread(() =>
//{
//    while (true)
//    {
//        if (threadCondition2)
//        {
//            for (int i = 10; i > 0; i--)
//                Console.WriteLine("Thread 2 => " + i);

//            threadCondition2 = false;
//            break;
//        }
//    }
//});

//thread1.Start();
//thread2.Start();



//// Monitor.Enter ve Monitor.Exit Nedir?

//object locking = new();
//var i = 0;

//Thread thread1 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Thread 1 => " + i);
//        }

//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});
//Thread thread2 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Thread 2 => " + i);
//        }

//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});

//thread1.Start();
//thread2.Start();
// Locking mekanizması da monitor enter ve exit kullanır arka planda

//// lockTaken Nedir ?


////Monitor.TryEnter Nedir ?
/// bir nesne üzerinde lock alınıp alınmadığını kontrol eder.


////Mutex Nedir ?
//Mutex mutex = new();
//Thread thread1 = new(() =>
//{

//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine("Thread 1 => " + i);
//    }
//    mutex.ReleaseMutex();

//});
//Thread thread2 = new(() =>
//{

//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine("Thread 2 => " + i);
//    }
//    mutex.ReleaseMutex();

//});
//thread1.Start();
//thread2.Start();

// mutex ile single instance application



// Locking ?
/// .NET9 İLE GELEN LOCK REFERANSI 

#endregion

