
using System.Threading.Channels;

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

#region Ders4Semaphore

//// Semaphore slim daha hafif ve yeni ama bazı yetenekleri de yok

// Semaphore Nedir ?
//List<int> numbers = new();
//using Semaphore semaphore = new(2, 2); // using ile çağırmak çok çok önemli bellek optimizasyonu için

//Thread thread1 = new(() =>
//{
//    semaphore.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine("Thread 1 => " + i);
//        numbers.Add(i);
//        Thread.Sleep(1000);
//    }
//    semaphore.Release();
//});
//Thread thread2 = new(() =>
//{
//    semaphore.WaitOne();
//    for (int i = 10; i < 20; i++)
//    {
//        Console.WriteLine("Thread 2 => " + i);
//        numbers.Add(i);
//        Thread.Sleep(1500);
//    }
//    semaphore.Release();
//});
//Thread thread3 = new(() =>
//{
//    semaphore.WaitOne();
//    for (int i = 20; i < 30; i++)
//    {
//        Console.WriteLine("Thread 3 => " + i);
//        numbers.Add(i);
//        Thread.Sleep(2000);
//    }
//    semaphore.Release();
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();

//// Semaphore Slim Nedir ?
// daha hızlı çalışır ve daha az bellek tüketir.
// asenkron davranış sergileyebiliyor. o yüzden asenkron yapılanmalarında slim kullanılır.

//// ideal bekleme süresi nedir ?
// semaphore.WaitOne(1000) => 1 saniye içinde işlemi yapamazsa işlemi iptal eder.





#endregion

#region Ders5ThreadSyncNonBlockingVolatile

//// Thread Synchronization Nedir ?




//// Non blocking synchronization Nedir ?
// yerine göre bloklama mantığından kaçılırsa fark yaratabilir. 


//// volatile keyword Nedir ?
// data register alanı ile veriler daha hızlı okunur.
// volatile ile işaretlersek direkt olarak bellekten alacak ve bu sayede veriye  en doğru formunda ulaşacağız
// asenkron ve multithread için önemli
// düşük seviyeli senkronizasyon için önemli eski bir yöntemdir.
//volatile static int i = 0;

#endregion

#region Ders6Interlocked
//// Interlocked Sınıfı Nedir ? 
// multithread işlemlerinde paylaşılan değişkenlere güvenli erişim için kullanılır
//int i = 0;
//// Interlocked.Add(ref i, 1); => i değişkenine 1 ekler

//var previousValue = Interlocked.Exchange(ref i, 5);
//Console.WriteLine(previousValue); // i değişkenini 5 yapar ve önceki değeri döndürür
//Console.WriteLine(i);




//Thread thread1 = new(() =>
//{
//    while (true)
//        //i++;
//        Interlocked.Increment(ref i); // güvenli şekilde refini alır ve 1 arttırır
//});

//Thread thread2 = new(() =>
//{
//    while (true)
//        Console.WriteLine(i);

//});

//Thread thread3 = new(() =>
//{
//    while (true)
//        //i--;
//        Interlocked.Decrement(ref i); // güvenli şekilde refini alır ve 1 azaltır => atomik seviyede işlem yapar


//});

//thread1.Start();
//thread2.Start();
//thread3.Start();

// İNTERLOCKED İLE VOLATİLE KEYWORD FARKI NEDİR ? 



//// Memory Barrier Nedir ?
// bellek erişimini düzenlemek ve optimize etmek için kullanılmaktadır.

//int i = 0;

//Thread writeThread = new(() =>
//{
//    while (true)
//    {
//          Interlocked.Increment(ref i);
//          Thread.MemoryBarrier();
//    }
//});

//Thread readThread = new(() =>
//{
//    while (true)
//    {
//        Thread.MemoryBarrier();
//        Console.WriteLine(i);
//    }
//});

//writeThread.Start();
//readThread.Start();

#endregion

#region Ders7SpinSync
//// Spinning Synchorization Nedir ?

//// SpinLock Nedir ? 
//int value = 0;
//SpinLock spinLock = new();

//Thread thread1 = new(() =>
//{
//    bool LockTaken = false;
//    try
//    {

//    spinLock.Enter(ref LockTaken);
//    if(LockTaken)
//        for(int i = 0; i< 999;i++)
//            Console.WriteLine("Thread 1 => " + i);
//    }
//    finally
//    {
//        if (LockTaken)
//            spinLock.Exit();
//    }

//});

//Thread thread2 = new(() =>
//{
//    bool LockTaken = false;
//    try
//    {
//        spinLock.Enter(ref LockTaken);  
//        if (LockTaken)
//            for (int i = 0; i < 999; i++)
//                Console.WriteLine("Thread 2 => " + i);
//    }
//    finally
//    {
//        if (LockTaken)
//            spinLock.Exit();
//    }

//});

//thread1.Start();
//thread2.Start();

//// SpinWait Nedir ?



#endregion

#region Ders8ReaderWriterLock

//// Reader Writer Lock Nedir ?

//// ReaderWriterLockSlim Nedir ? 


#endregion

#region Ders9SignallingandEvents
//// Signalling Nedir ?


//// ManualResetEvent Nedir ?


//// AutoResetEvent Nedir ?

//int counter = 0;
//AutoResetEvent autoResetEvent = new(false);

//Thread thread1 = new(() =>
//{                         
//    while (counter < 10)  
//    {                     
//        Console.WriteLine($"Thread 1 => {++counter} ");
//        Thread.Sleep(500);
//    }
//    autoResetEvent.Set();
//});
//Thread thread2 = new(() =>
//{
//    autoResetEvent.WaitOne();
//    while (counter < 20)
//    {
//        Console.WriteLine($"Thread 2 => {++counter} ");
//        Thread.Sleep(500);
//    }
//    autoResetEvent.Set();

//});
//Thread thread3 = new(() =>
//{
//    autoResetEvent.WaitOne();
//    while (counter++ < 30)
//    {
//        Console.WriteLine("Thread 3 => " + counter);
//        Thread.Sleep(500);
//    }
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();


//// CountdownEvent Nedir ?

#endregion


#region Ders10ThreadPoolWaitHandles
//// RegisterWaitForSingleObject  Nedir ?


//// WaitAny, WaitAll, SignalAndWait Nedir  ?

//// ThreadPool Nedir ?
// İçinde queue yapısı vardır. threadleri tutar
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Thread 1");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Thread 2");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Thread 3");

//Console.Read();
//void WorkerMethod( object state)
//{
//    string name = (string)state;
//    Console.WriteLine($"{name} => is working");
//    Thread.Sleep(1500);
//    Console.WriteLine($"{name} => is done");

//}

#endregion

#region Ders11BarrierClass

//// Barrier Class Nedir ?
// bir grup threadin belirli bir zamanda belirli bir yerde eş zamanlı olarak çalışmasını sağlar.

//Barrier barrier = new(3, _ => Console.WriteLine("---THREAD BARRIER---"));

//Thread thread1 = new(() =>
//{
//    for (int i = 0; i < 5; i++)
//        Console.WriteLine($"Thread 1.1  - {i}");

//    barrier.SignalAndWait();

//    for (int i = 0; i < 3; i++)
//        Console.WriteLine($"Thread 1.2  - {i}");
//});

//Thread thread2 = new(() =>
//{
//    for (int i = 0; i < 5; i++)
//        Console.WriteLine($"Thread 2.1  - {i}");

//    barrier.SignalAndWait();

//    for (int i = 0; i < 3; i++)
//        Console.WriteLine($"Thread 2.2  - {i}");
//});

//Thread thread3 = new(() =>
//{
//    for (int i = 0; i < 5; i++)
//        Console.WriteLine($"Thread 3.1  - {i}");

//    barrier.SignalAndWait();

//    for (int i = 0; i < 3; i++)
//        Console.WriteLine($"Thread 3.2  - {i}");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();

#endregion


#region Ders12TlsandThreadStatic

//// Thread Local Storage Nedir ?
// Thread Local Storage (TLS), her iş parçacığının kendi bağımsız verisini saklamasını sağlar.

//// ThreadStatic Nedir ?
//// ThreadLocal<T> Nedir ?
///
//ThreadLocal<int> x = new(() => 0);


//Thread thread1 = new(() =>
//{
//    while (x.Value <10)
//    { 
//        x.Value++;
//        Console.WriteLine("Thread 1 => " + x.Value);
//    }

//});

//Thread thread2 = new(() =>
//{
//    while (x.Value < 10)
//    {
//        x.Value++;
//        Console.WriteLine("Thread 2 => " + x.Value);
//    }

//});

//Thread thread3 = new(() =>
//{
//    while (x.Value < 10)
//    {
//        x.Value++;
//        Console.WriteLine("Thread 3 => " + x.Value);
//    }

//});

//thread1.Start();
//thread2.Start();
//thread3.Start();





#endregion


#region Ders13Timers

//// MultiThreadTimers Nedir  ? 

//Timer timer = new((state) =>
//{
//    Console.WriteLine(state);
//}, "tick tack toe", 2000, 1000);

//Thread.Sleep(6000);
//timer.Change(0, 500);

//Console.Read();
//// Single Thread Timers Nedir ?
// tek thread tarafından kullanılırlar ve paralel çalışma yürütülmez

#endregion


#region Ders14Task
//// Task Sınıfı Nedir ? 

//// new Task
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine("Task 1 => " + i);
//    }
//});
//task.Start();

////Task Run
//Task.Run(() =>
//{
//        for (int i = 0; i < 10; i++)
//             Console.WriteLine("Task 1 => " + i);

//});

//// Task.Factory.StartNew
//var task = Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine("Task 1 => " + i);

//});






//// Metotlar & Propertyler Nedir ?
//Task task = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine("Task 1 => " + i);

//});
//Task task2 = Task.Run(() =>
//{
//    for (int i = 10; i < 20; i++)
//        Console.WriteLine("Task 2 => " + i);

//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 20; i < 30; i++)
//        Console.WriteLine("Task 3 => " + i);

//});

//// Start
//task.Start(); // burada hata alırız çünkü task run ile başlatıldı

//// Wait
//task.Wait(); // task bitene kadar bekler
//Console.WriteLine("Task Bekledi");

//// ContinueWith
//task.ContinueWith(t =>
//{
//    Console.WriteLine("Task Bitti");
//});

//// WaitAll
//Task.WaitAll(task,task2,task3);
//Console.WriteLine("Tasklar Bitti");

//// WhenAll
//await Task.WhenAll(task, task2, task3); // async metotlarda kullanılır ve tasklerin bitmesini bekler ve devam eder
//Console.WriteLine("Tasklar Bitti");

//// WaitAny
//Task.WaitAny(task,task2,task3);
//Console.WriteLine("Task Bitti");

////  Delay
//await Task.Delay(2000);
//Console.WriteLine("Task Bitti");

//// FromCanceled
//await Task.FromCanceled(new CancellationToken(true)); // taski iptal eder
//Console.WriteLine("Task İPTAL");

//// FromException
//await Task.FromException(new Exception("Hata Oluştu")); // taski hata ile sonlandırır

//// FromResult
//Task<int> task4 = Task.FromResult(5); // taski başarılı bir şekilde sonlandırır
//Console.WriteLine(await task4);

////Propertyler Nedir ?
//CompletedTask // başarılı bir şekilde sonlandırılmış task
//CurrentId // taskin id sini döner
// Factory // yeni task nesneleri oluşturmak için kullanılan propertydir.
// IsCompleted // taskin tamamlanıp tamamlanmadığını döner
// IsCanceled // taskin iptal edilip edilmediğini döner






#endregion


#region Ders15TaskScheduler

// TaskFactory Nedir ?
// task instance oluşturup yönetmek için kullanulan bir sınıftır.
//Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine("Task 1 => " + i);

//});
//  ContinueWhenAll  => bu da asenkron çalışır
//Task task1 = new(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine("Task 1 => " + i);
//});
//Task task2 = new(() =>
//{
//    for (int i = 10; i < 20; i++)
//        Console.WriteLine("Task 2 => " + i);
//});
//Task task3 = new(() =>
//{
//    for (int i = 20; i < 30; i++)
//        Console.WriteLine("Task 3 => " + i);
//});




//task1.Start(); 
//task2.Start();
//task3.Start();

//TaskFactory taskFactory = new();

//////ContinueWhennAll
//// taskFactory.ContinueWhenAll(new Task[] { task1, task2, task3 }, tasks =>
////{
////    Console.WriteLine("Tasklar Bitti");
////});

//////ContinueWhenAny
//await taskFactory.ContinueWhenAny(new Task[] { task1, task2, task3 }, tasks =>
//{
//    Console.WriteLine("Tasklar Bitti");
//});

//Console.Read();


//TaskScheduler Nedir ?
// Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine("Task 1 => " + i);

//}, new(), TaskCreationOptions.None, new CustomTaskSchedular());


//class CustomTaskSchedular : TaskScheduler
//{
//    protected override IEnumerable<Task>? GetScheduledTasks()
//    => null;

//    protected override void QueueTask(Task task)
//    => ThreadPool.QueueUserWorkItem(_ => TryExecuteTask(task));

//    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
//    => true;
//}


//TaskCompletionSource Nedir ?


#endregion


#region Ders16AsyncAwait
// task generic task ya da void olabilir ama best practice açısından void olmaz
//async Task X () { };
//async Task<int> Y() { return 45; };
//async void Z() { };

// async Task<string> ReadFileAsync()
//{
//    StreamReader streamReader = new("C:\\Users\\keleb\\source\\repos\\AsynchronousandMultithreading\\deneme.txt");
//    string content = await streamReader.ReadToEndAsync();

//    // burada async kullanmak zorunlu ve task dönerse await kullanılabilir.
//    //Action action = async () =>
//    //{
//    //    await Task.Delay(2000);
//    //};
//    // action();
//    return content;

//}

//var result = await ReadFileAsync();
//Console.WriteLine(result);

//Console.Read();
#endregion


#region Ders17CancellationToken

#region ConfigureAwait

//async Task<string> ReadFileAsync(string path)
//{
//    StreamReader streamReader = new(path);
//    var content =  await streamReader.ReadToEndAsync().ConfigureAwait(false);
//    Console.WriteLine("---END---");
//    return content;
//}

//var content = await ReadFileAsync("C:\\Users\\keleb\\source\\repos\\AsynchronousandMultithreading\\deneme.txt");
//Console.WriteLine(content);

#endregion

#region CancellationToken & CancellationTokenSource

//async Task DoWorkAsync(CancellationToken cancellationToken)
//{

//    for (int i = 1; i <= 10; i++)
//    {

//        cancellationToken.ThrowIfCancellationRequested();
//       await Console.Out.WriteLineAsync($"{i} => Döngü");
//        await Task.Delay(1000);
//    }

//    Console.WriteLine("İşlem Bitti");


//}


//CancellationTokenSource cancellationTokenSource = new();

//Task.Run(async () =>
//{
//    Thread.Sleep(5000);
//   await cancellationTokenSource.CancelAsync();
//});

//try
//{
//await DoWorkAsync(cancellationTokenSource.Token);


//}catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);

//}



#endregion

#region Task & ValueTask
// ValueTask<int> HesaplaHizliAsync(int sayi)
//{
//    // Sonuç hemen hesaplanabiliyorsa, yeni bir Task oluşturmadan döndürmek için ValueTask kullanılabilir.
//    int sonuc = sayi * sayi;
//    return new ValueTask<int>(sonuc);
//}

// async Task MainAsync()
//{
//    int sonuc = await HesaplaHizliAsync(5);
//    Console.WriteLine($"Hızlı Sonuç: {sonuc}");
//}

//await MainAsync();


#endregion


#endregion


#region Ders18IAsyncEnumerable

//async IAsyncEnumerable<int> GetNumbersAsync()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        yield return i;
//        await Task.Delay(1000);
//    }
//}

//await foreach (var number in GetNumbersAsync())
//{
//    Console.WriteLine(number);
//}


#endregion


#region Ders19ConcurrentCollections


#endregion


#region Ders20ChannelsLibrary
//// Ders19 kodlarını yaz.

//var channel = Channel.CreateBounded<int>(5);

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 20; i++)
//    {
//       await channel.Writer.WriteAsync(i);
//        await Console.Out.WriteLineAsync($"Producer => {i}");
//        await Task.Delay(1000);
//    }
//    channel.Writer.Complete();

//});


//Task consumer = Task.Run(async () =>
//{

//    await foreach( var item in channel.Reader.ReadAllAsync())
//    {
//        await Console.Out.WriteLineAsync($"Consumer => {item}");
//        await Task.Delay(2000);
//    }

//});


//await Task.WhenAll(producer, consumer);

//Console.Read();

#endregion

#region Ders21StructuredConcurrency

// async Task ProcessDataAsync(CancellationToken cancellationToken)
//{
//    // Üç farklı asenkron işlemi paralel olarak başlatıyoruz
//    var task1 = DoWork1Async(cancellationToken);
//    var task2 = DoWork2Async(cancellationToken);
//    var task3 = DoWork3Async(cancellationToken);

//    // Structured concurrency: Tüm alt görevler ana işlemin bir parçası olarak bekleniyor.
//    // Eğer herhangi biri hata verirse, tüm görevler iptal edilebilir.
//    await Task.WhenAll(task1, task2, task3);
//}

// async Task<string> DoWork1Async(CancellationToken cancellationToken)
//{
//    await Task.Delay(1000, cancellationToken);
//    Console.WriteLine("İş 1 tamamlandı");
//    return "İş 1 tamamlandı";
//}

// async Task<string> DoWork2Async(CancellationToken cancellationToken)
//{
//    await Task.Delay(1500, cancellationToken);
//    Console.WriteLine("İş 2 tamamlandı");
//    return "İş 2 tamamlandı";
//}

// async Task<string> DoWork3Async(CancellationToken cancellationToken)
//{
//    await Task.Delay(2000, cancellationToken);
//    Console.WriteLine("İş 3 tamamlandı");
//    return "İş 3 tamamlandı";
//}

//await ProcessDataAsync(CancellationToken.None);

//Console.Read();
#endregion