# Intro to C# and .NET

## History

    Operating System
        Makes a bit of hardware:
            Motherboard
            Processor
            RAM
            Network Card
        MAkes the hardware work

    Common operating systems were originally written in C
        UNIX was the original       Paid, closed source
        IOS/OSX                     UNIX derivitive, closed source
        Windows                     Closed
        Linux (UNIX-like OS)        Open source == good stuff!!

                Windows .NET is now open source.
                
                FLOP Floating Point Operation
    Programming LAnguage 
        C > C++(still in use today)
            c++ for 'raw coding'
        However
            Java
                runs in JVM (virtual machine)
            C#
                Microsoft pushing for this
                    F# > Functional Programming Language
            Python
                Good for engineering and data science
            Give the benfits of C++ without the drawbacks

    Cloud
    Traditional Computing
        Run on local hardware
        Today > different
        Newer companies are moving services to the cloud
            a) AWS Amazon           70%ish of market
            b) Azure                25%ish          Microsoft are getting most of their £££ from this
            c) Google Cloud         5%ish
        Container
            Mini VM > runs individual apps
            Group of containers is managed using Kubernetes (open source)
        Function as a service
            Individual methods which you can call from cloud

    Structure of an application
    .NET
        old, huge, cumilative libraries for all Windows
    .NET Core
        new, streamlined, valid on: Linux, Mac and Windows

    .sln
        xlm file, with all the names of all the projects
        'contatiner' no function of itself
            just to hold multiple projects

    .csproj
        meta data for individual projects

    Program.cs
        Has the actual code

        class Program{
        public static Main(){
                //Code goes here
            }
        }

## .NET structure

    To build a program with C# or dotet you need
        CLI Common Languge Infrastructure
            Rules for language
        CLR Common Language Runtime
            program runs in this enviroment
            Garbage collector
                Reclaims memory when you are finished with an object
        CSC C Sharp Compiler
            Turns .cs text into a .exe
        CIL Common Intermediate Language
            Half-Compiled Code
                Assembly language ish

            CS(raw code) > CIL > CRL

                    Tool called 'ILDASM' > inspect .exe and view CIL compiled code

## Object Oriented Programming

    Traditional computing has been linear programming where code starts at line 1 and finishes at the end.
    OK but when GUI was invented, screen object appeared. 
        Button
                Click event
                        Method/Function     (Event Handler)
        OBJECT  EVENT   METHOD (CODE)

    An object looks like
    {
        id:1                                field:value (key/value pairs)
        name:bob                            
        dob: "10/10/2001"
        likes: {"strawberries", "pizza"}
    }

    Array [1, 2, 3]
    String "Some Text"
    Number
        int
        double 64 bits / float 32 bits / decimal types 128 bits

## Creating an Object

    Class
        Template/Blueprint for creating an object
        e.g.
        class Mammal{
            int height, weight, length;
            string type;
        }
    var m01 = new Mammal();

    m01.height = 10;
    m01.weight = 9999;
    m01.length = 999999;
    m01.type = "snek";

```cs
    static void Main(string[] args)
        {
            var dog1 = new Dog();

            dog1.Age = 10;
            dog1.Height = 50;
            dog1.Name = "Bob";

            //Console.WriteLine("Hello World!");
            Console.WriteLine($"The dog's name is {dog1.Name}, age {dog1.Age} and height is {dog1.Height}cm.");
            Console.ReadLine();
        }

        class Dog
        {
            public string Name;
            public int Age, Height;
        }
```

    Methods are functions
        they can be called to get something done
            e.g. Lets grow our dog

```cs
    Grow()
    {
        Age = Age + 1;
        Height = Height + 10;
    }
```

## Private and Public Fields

```cs
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.name = "Fantasia";
            //person01.NINo = "stuff";      Doesn't work;
            person01.SetNINo("asdfghkjl");
            Console.WriteLine($"{person01.name}'s NINo is {person01.GetNINo()}.");
        }

        class Person
        {
            private string NINo;
            public string name;


            public string GetNINo(){return NINo;}

            public void SetNINo(string newNino){this.NINo = newNino;}

        }
```

## Fields and Properties

    Class
        Fields
            in a class, Fields tend to be private.
            camelCase
            OR
            _camelCase
        Properties
            tend to be public
            PascalCase      (ThisIsAPublicProperty)
            get; / set;

```cs

class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age); //Comes out as 0 (default int value)
        }
    }

    class Rabbit
    {
        private int _bloodType;
        private int _age;
        public string Name { get; set; }

        public int Age {
            get
            {
                return this._age;
            }
            set
            {
                if(value >= 0)
                {
                    this.Age = value;
                }
            }
        }
    }
```

## Creating Multiple Objects

    Array has a FIXED size

    List written
        List<int>() has a variable size
            Can be used to add items to a list

## Inheritence

    Methods in more Detail
        convention
            name is PascalCase          void DoThis()

        Parameters
            are passed in               void DoThis(int x, string y){}

        return 
            passed out                  string DoThis { return "hi"}

        optional
            passed in                   void DoThis(int x = 1000){}
                                        pass in but if missing set value to 1000

        out parameters pass out         void DoThis(intx, y, out int z)

    Tuple
        Fancy new variable
            (int x, string y, bool z)
                This is now a custom data type

```cs
    static void Main()
    {
        //method INSIDE method
        void DoThis()
        {
            Console.WriteLine("I am doing a thing");
        }

        //to call the method
        DoThis();
        DoThisToo();


        MulitplyNumbers(5);        //gives 500
        MulitplyNumbers(5, 1000);  //gives 5000

        OutParameters(2, 5, out int a);         //a = 2 * 5

        var output = Tuple();
        Console.WriteLine(output.x, output.y, output.z);
    }

    static void DoThisToo()
    {
        Console.WriteLine("I am doing a thing too");
    }


    static void MulitplyNumbers(int y, int x = 100)
    {
        Console.WriteLine(x*y);
    }

    static void OutParameters(int x, int y, out int z)
    {
        z = x * y;
    }

    static (int x, string y, bool z) Tuple()
    {
        return (2, "Yo", true);
    }
```

## Other

    Comment: ctrl + K + C
    Uncomment: ctrl + K + U

## Testing Example

```cs
            [TestCase(1000, 20)]
        public void TestRabbitExplosion (int popLimit, int expectedYears)
        {
            var actual = just_do_it_11_rabbit_explosion.Rabbit_Exponential_Growth(popLimit).ToTuple().Item1;
            Assert.AreEqual(expectedYears, actual);
        }
```

## OOP Continued

### Abstract Classes

#### So far we have

```cs
    class Mercedes{
        private in _privateField;               //ENCAPSULATION field (private)

        public string Name{get;set;}            //ABSTRACTION  property (public)

        public void DoThis(){}                  //method: Verb : Action Code

        public Mercedes(){}                     //Constructor : same name as class

        var instance = new Mercedes();          //instance is a new object from the class
    }
```

    Class is a template for new objects

    Normal class is a CONCRETE class because we can create real objects/instances from it.

### Mind picture for abstract classes

#### Holiday in planning

```cs
        class Holiday{
            public void TravelPlans(){}
            public void PlacesToVisit(){ cw("This list is now complete")}
            public void Activities(){ cw("All activities planned out")}
                                    //|---> CODE IMPLEMENTATION        <---|
        }
```

    One method (TravelPlans) has no code implementation

    This method is an abstract, because it exists but has no code body

    changes made:
                public void TravelPlans(){}
                public abstract mvoid TravelPlans();
    If one method is abstract then the class has to be abstract too.
                class Holiday{
                abstract class Holiday{

    One method has no code implementation
        It exists but has no code body
        public abstract void TravelPlans();

    Solution is to derive Sub-Class and inherit from abstract class
        PARENT : ABSTRACT       

        CHILD : 

```cs
       abstract public class Holiday
        {
            public abstract void TravelPlans();
            public void PlacesToVisit()
            {
                Console.WriteLine("Visiting Vienna, Salzburg");
            }
            public void Activities()
            {
                Console.WriteLine("Skiing, Walking, Fishing");
            }
        }

        public class HolidayWithTravel : Holiday
        {
            public override void TravelPlans() { Console.WriteLine("By train eurostar, then plane, then car"); }
        }
```

## Sealed Classesd

    When dealing with security, it might not be a good idea that people can inherit from a secure class but then introduce vulnerabilities.

    RealWorld
        Car engine : seal inside secure combustion chamber / chassis so amatuers dont mess with the engine and cause accidents.

        CPU : Discourage overclocking

    Coding
    ```cs
            sealed class Security{
                //Cannot inherit from this
            }
    ```

## Extending a sealed class

    String is a sealed class with lots of methods liek this one

    ```cs
        static void Main(string[] args)
        {
            string x = "Hello World";
            if (x.StartsWith("Hello"))
            {
                Console.WriteLine("World");
            }
        }
    ```

Imagine we want to build our own

    ```cs
        public static class 
        {
            public static void Amazing ExtraStringMethod(string s)
            {
                s = s + "String to add"
            }
        }
    ```

## WPF Application

    3 areas of learning

    Console : MOST LEARNING HERE

    WPF : Provides a screen where we can palce objects
        Goal: 
            1) Busioness interface
            2) Canvas: Simple images for a game (Crude)
    Websites : Focus on business style application
        Functioning data
            1) ASP Regular Website
            2) MVC Website

    WPF is Windows Presentation Foundation
        xml skeleton for gUI
        C# code behind it

            XML
    ```xml
                    <root>
                        <row>
                            <col attribute="dataherealso">data</col>
                        </row>
                        <row>
                            <col attribute="dataherealso">data</col>
                        </row>
                        <row>
                            <col attribute="dataherealso">data</col>
                        </row>
                        <row>
                            <col attribute="dataherealso">data</col>
                        </row>
                    </root>
    ```
    Microsoft loves xml

    Everyone else loves JSON

## OOP Practise + Internal Keyword

    class Myclass{

        private int _hideMe;       //field      (Encapsulation)
        public string NAme {get; set;}      //property      Abstraction
        public void DoThis()
        {

        }

    }

    abstract class Idea{
        abstract void DoThis();     //No Implementation

    }

    class SolidThoughts : Idea{
        override void DoThis(){}
    }

    ABTRACT CLASS > CANNOT INSTANTIATE
    CONCRETE CLASS > CAN INSTANTIATE

        car m = new MyClass();

    Polymorphism
        Parent : virtual interfa
        Child : override    (optional)

    Abstract
        Parent : abstract 
        Child : override    (Mandatory)

    Inheritence
        Parent : Child

        Access Modifiers:public, private, protected, internal
        public 
            See from any other class
        private
            Hidden inside the class
        protected
            hidden inside a class and all child classes
        internal
            within the compiled exe. visible in this scope.

## Static

    ```cs
    class Myclass{
            private int _hideMe;                    //instance
            public string Property01 {get; set;}    //instance
            public void Method01()                  //instance

            public MyClass(){}
            {

            var m = new MyClass();
                m = instance;
                    m.Property01;
                    m.Method01();
            Math.PI;
            Math.Random();
            Math.Round();
                            STATIC MEMBERS ATTACHED DIRECTLY TO THE MATH CLASS
                            '
            clas MyClass{
                static public int Property01{get;set;}
                static public void DoThis(){}
            }
                MyClass.Property01;
                Myclass.DoThis();
    ```
    Mind picture
        User (instance) with  shopping basket
        static count of total items in stock

## SQL

    Relational Databse using Structured Query Language

        Microsoft           MSSQL  (paid product)
        Free                MYSQL

        Relatiobnal datgabases have
            Tables
                ID
                Fields

            User
                UserID
                UserName
            
            Category
                CategoryID
                CategoryName

            We can crate relationships

            USer
                UserID
                UserName
                CategoryID;     //Foreign key

            ID (IDENTITY)   >   Unique, Auto-Increment to Highest Value

    Today
        Basic SQL
            Create a database
                rabbit tables
            Entity
                C# > hook into the database
                     View, update rabbits

     SQL Commands
        View > Server Explorer. Data conection, Add
            (localdb)\mssqllocaldb
        View > SQL Object Explorer

            Gives access to the local computer using sql server

            Files called ....mdf micrsoft Datavase File
            Stored in C:\Users\%username%\folder

    Connecting to a database
        Microsoft can connect directly to a database using Entity Framework
            EF6: Framework
            EFCore : Lighter / open source
        If we being using EF6, there is more supprt, so its easier to get going

        New Console App(Framework)
        Add entity
        Connect to database
        View Rabbits

## Homework

    NEw WPF Just_Do_It_12_Rabbit_Explosion using .NET Framework
    Add 2 text boxes and an ADD button
    Add entity
    When you click the ADD button 
        ADD A NEW RABBIT
        DISPLAY A NEW RABBIT PICTURE FOR ONE SECOND

    Create a TEXTBLOCK and do a for each loop to output the rabbit data into this text block

## Tuesday 10th REview

    Agile
        SCRUM
            Sprint
                1-4 weeks focused work
                Goal of a sprint
                    To implement a new feature
                    Called a release
                    New increment of a version
                        Breaking change     1.0
                                            2.0
                                            3.0

                        Version Increment   1.1
                                            1.2
                                            1.3

            3 Pillars of SCRUM
                Transparency
                Inspection
                Adaptation

            Agile Manifesto
                people over processes
                Working software over documentation
                Collab over negatioation

            SCRUM Roles
                SCRUM master
                    admin, focus/flow, remove blockers
                SCRUM Dev
                    Develop stuff
                    3-9 people, self organising
                Product Owner
                    Owns backlog and lease with customer
            BackLog
                To do list of project
            Sprint backlog
                mini to do list for just this sprint

        Waterfall           Good for fixed/small projects that are unlikely to change
            Traditional Model
            REquirments
            Analysis
            Design
            Build
            Test
            Release
            Maintain
            Document

        V-Model
            Adding testing to each stage of waterfall
            For critical grade systems
            Life is at stake
        Unit testing
            Test individual units/modules of code at the smallest level
        intergration testing
            Join modules together
        system testing
            Testing overall system
        UAT User acceptance testing
            User validates that the code meets the aggreed list of requirements
        Feasability study
            Initial guidance for the client
                Techinically
                    Can we do it?
                Finacial
                    Can we afford it/will it make money?
        alpha release
            Initial release, often by invitation only. 
            Typically journalist, specialists, stakeholders
        beta release
            Public testing, looking for feedback from public, not final version. Customers get early access/free game
        Regression testing
            Ensures that when you build a new feature or fix a bug it doesnt break existing code
        White box
            Look for logical errors in code.
            code line by code line
        Black Box
            Input outout only.
            Know nothing about the code
        JIT just in time
            Production line
                Minimise waste
                24/7 processes
        RGR Testing
            Red
                Build tests that will fail
            Green
                Write code to pass the tests
            Refactor
                Optimise/maintain
        Minify
            Make code as small as possible to save space
        WorkFlow
            Work flow for continuous
                Limit active work in progress
                Few things in dev at a time

## OOP Practise

    Fields
        Member variable of a object/class
        Usually private
    Properties
        Public access variable with a get and set method of an object/class
    Class
        Blueprint for an object/a collection of methods
    Method
        A small function (used for modular code)
        PascalCase
    Constructor
        Create a new instance with minimum work
    Overload
        Same method
            different parameters
    Abstract Class
        Class with one or more abtract methods
        CANNOT instantiate an abtract class
        Have to derive a child class with implements all methods
            THEN you can instantiate
    Abstract Method
        Method with no body
    Cocrete class
        standard class
            standard methods
        CAN instantiate

## OOP Pillars

    Polymorphism
        Inheritence with optional overide
    Encapsulation
        Private members within a class
        Members:
            Something that belongs to a class
            Access modifiers
                Private       only in class
                public      anywhere
                protected   Parent and children
                Internal    within exe/dll
    Inheritance
        Children can inherit properties from parent
        Parent : Child
        Base : Derived
    Abstraction
        You use public properties to interact with encapsulated members

    Abstract class
            Class with one or more abtract methods
        CANNOT instantiate an abtract class
        Have to derive a child class with implements all methods
            THEN you can instantiate

    Abstract method
        Method with no body/implementation (must be overwritten)

    Abstract (dictionary)
        Vague. Concept. Not tangible.

    Abstracted out of a situation:  
        Made distant from the complexity of a situation

    Abstract as a pillar
         You use public properties to interact with encapsulated members

## Structs

    Struct is a mini class
    only has fields which are fully public and any methods are fully public
    Stored in fast memory of computer called the stack memory
    Like primitives >  integers, char, boolean, bytes

    e.g. struct Point(int x, int y)

## Collections

    Arrays and collections

    Arrays are a fixed size
    Colections are variable sized
    whwen reading and writing data the comp will map ram address to each array member and will go straight ti the memory address when looking at it

    Arrays in memory
        every cell has a a unique alloccated memory address
        IEnumerable => means can count numerically over the array

    Collections
        Generics <T> T = any data type
                                int, string, char, MyClass
            List<int>
            List<Rabbit>
            List<Customer>

        List<int>       
            Index value like an array
            Insert or remove items anywhere in the list

        Queue<int>      
            No index, cannot get items out of the middle
            FIFO, first in first out
            Enqueue(add new person to the back of the queue)
            Dequeue(take first person)
            Peek(check first item)
            Contains(boolean does the queue contain ...)
            Uses: Printing, Email, Batch processing.

        Stack<int>
            Run an app
            First method is called main
            Stack is used to order running code
                Every method is frozen apart from the top method with is active
                    Peeling off the stack => Finished
                    All held memory is discarded when a method is peeleD
            LIFO
                Last In First Out
            Methods
                Push
                    Push new item on top
                Pop
                    Remove top item
                Peek
                    Same
                Contains
                    Same

        Dictionary<TKey, TValue>
            TKey must be unique
        ArrayList (object)
            List of objects
                Any type goes
        Hashset<int>
            Fast but has no order (i.e. no index)
            Has unique values but has no index
        LinkedList<object>

## LINQ

    LINQ is a special language is a special language generated by Microsoft to read databases.

    LINQ has two types
        from c in customers
        where c.City = "Berlin"
        select c

        customers.Where (c => c.City == "Berlin");

## Getting started

    Microsft have their own test database
        Northwind   Business database with customers
        Adventure Works

## Loops

    For
        Useful for when we know how many loops we need
        Good for arrays because we get an index for each loop

        for(i = 0; i < x;i++)
        {

        }

    ForEach
        Looping through a Collection

        ForEach(element in Collection)
        {
            action
        }

    While
        Loop until a condition is met
        May never execute

        while(x < 10)
        {
            action
        }

    Do...While
        Loop while a condition is true
        executes a minimum of one time

        do
        {

        }while(x < 10)

    Break
        Useful for avoiding nested loops
        Breaks out of loops completely

        for(i = 0; i < 10;i++)
        {
            if(i == 5)
            {
                break;          //Breaks out of loop
            }
        }

        //Nested
        if(condition)
        
            if(othercondition)
            {
                if(otherothercondition)
                {

                }
            }
        }

        //Using break
        if(!condition)
        break;
        if(!othercondition)
        break;
        if(!otherothercondition)
        break;

    Continue
        for(i = 0; i < 10;i++)
        {
            if(i == 5)
            {
                continue;          //continues to next loop
            }
        }

## Github Pull Requests

    1.Dev branch
    2.Make Change + push
    3.Set new origin > dev
    4.Lock Master and require one pull approval
    5.Add colaborators
    6.Add approvers for this pull request : send for approval
    7.Approver get email check code and approve/deny with comments

## HTML CSS and Javascript

### Modern Web

    Check the end from the beginning
        The web is so exciting
            theres lots to explore
        HTML        =           Hyper Text Markup Language : Provides skeleton for your page

    ```html
        <html> <p> This is a paragraph </p> </html>

        <tag>
        <img src="html..." width="200" height="300" />      src is the attribute of the tag
    ```    

    ```html
        <html class="gr__">

        <head>
            <meta http-equiv="content-type" content="text/html; charset=UTF-8">
        </head>

        <body data-gr-c-s-loaded="true">

            <title>Sample Page</title>
            <style>
                /*CSS styles the page*/
                title {
                    text-align: center;
                }
                body {
                    background-color: #285B80;
                    color: black;
                    font-family: Verdana, Geneva, Tahoma, sans-serif;
                    font-size: 1.2em;
                }
                nav#mainNav {
                    background-color: #4E6B80;
                    margin-left: 15%;
                    padding: 3vh 2vw;
                }
                nav#mainNAv li {
                    list-style: none;
                    display: inline-block;
                }
            </style>
            <script>
                /*JavaScript makes things happen*/
            </script>

            <h1>Title </h1>
            <h2>Title 2</h2>
            <!--Comment-->
            <nav id="mainNav">
                <ul>
                    <li>
                        <a href="#">Home</a>
                    </li>
                    <li>
                        <a href="#">About</a>
                    </li>
                    <li>
                        <a href="#">Contact</a>
                    </li>
                </ul>
            </nav>

            <div>
                <p><strong>DIV is a division on a page</strong></p>
            </div>
            <header>Sections are: header</header>
            <section>Section</section>
            <aside>Aside</aside>
            <footer>Footer</footer>
            <footer>asdf</footer>

            <style>
                div.box {
                    background: #4E6B80;
                    margin-left: 10%;
                    padding: 10vh 10vw;
                    width: 10vw;
                    height: 10vh;
                    margin: 2vh;
                    display: inline-block;
                    display: flexbox;
                }
                div.BoxContainer {
                    margin-left: 10%;
                    border: 1px solid black;
                }
            </style>
            <div class="BoxContainer">
                <div class="box"> here is a box</div>
                <div class="box"> here is a box</div>
                <div class="box"> here is a box</div>
                <div class="box"> here is a box</div>
                <div class="box"> here is a box</div>
                <div class="box"> here is a box</div>
            </div>
        </body>

        </html>
    ```

### BootStrap

    Building raw from html can be very time consuming. Its much better to find an amazing template online and use that.

    Bootstrap also provides good ways to get started quickly on a website
    prov-ides all code for free and you just drop the code in

### NodeJS

    javascript took over te web because netscaoe navigator invented it but everyone adopted it

    today javascrit powers most uf not all of our breowsers

    but smart peaople from google took javasctioe out of the browsers and made it to run standalone without the browsers
        CALLED NODEJS

### Building a Node Server

    When using node js we can refrence existing libraries.
    to install them use
        npm install <library name>#
    global install
        npm install -g <library name>
    Then use the library with 
        var myVariable = require('<libraryname>')
        var http = require('http')

### ReactJS

    ReactJs builds a virtual webpage then displays it as a real web page
    React can just update the bits which are changed, making dynamic pages faster 

### 16/09

    1) SQL
        Tables/Relationships
    2) CRUD app 
        Console Version
        WPF Version
    3) Create 1000 objects
        one using (var db) READ
            loop though and read after
            Time it
        1000 using (var db) READ
            loop through and read while looping
            Time it
    4)  Canvas
            Image move on  wpf finish
    5)  Report timing results using 
            csv to excel
            something to word

### Interfaces

    Classes 
        Concrete class
            Means we have the

            class
            {
                Fields
                Properties
                Methods
            }               (All complete so we can instantiate with the NEW keyword which calls the constructor method)

        Abstract class
            abstract class
            {

            }               (An abstract class is a class with at least one method that has no body.
                            An abstract method is a mrthod with no implmentation.)


        Interface Class
            An interface is a fully abstract class, with absolutely no body of code in its methods

            interface IDoThis{
                (((abstract))) void DoThis();
            }                                           (((abstract is implied not stated)))

        Parent Abstract class
            Child Abstract Class            (Can only be a child to one parent)
            Child can also not just inherit from one parent, it can also implement or use many interfaces.


        E.G.
            Parent Abstract Person{}    //Abstract

            Child User : Person{}       //Concrete

            Child User : Person, IuseThis, IUseThat{}   //Implement 2 interfaces


            interface IUseThis{
                void IDoThis{};
            }

            interface IUseThat{
                void IDoThat{};
            }

            In the user class we have to build or implement code for these interface mthods IDoThis and IDoThat. 
            Mind picture is that each individual will use a tool in a slightly different way.


            Interfaces are usefiul in large apps cause the create standardisation of how classes will have expected behaviour

                E.g.
                    int.ToString();
                    char.ToString();

                    child.DoThis();
                    child.DoThat();

### Tasks

    ##Background Terms

        CPU     MultiCore ie several CPUs joined together
                    One CPU: Process info in threads
                    Multi-core: Can ignore this as a developer but now we can ignore it and let tassks handle it

        Process is an exe or dll file. ACtually DLL files tend to be dormant 'libraries' of code which get used or 'refenced'. So actually on your comp it's the .EXEs which are executables whichc run your applications. They can refrence DLL libraries but it's the EXE which shows up as a runing process.

            Task List
            get-process
            taskkill -pid 123456

        Thread : set of instructions sent in a batch to cpu for processing


        Application : runs on user request after user log on

        Service : Runs on system request after system boot : can be ok to run whether or not a user is present

### C# Threading/Tasks

    Threads
        Are a very detailed develpoer tool to have very fine control over background threads created.
        It's a lot of work.

    Tasks
        Tasks are a wrapper over threads. Abstract the programmer away from the hard work of creating and managing threads. 

        Tasks are background processes. We hand all control over the running of eack task to the OS. As a developer we have no control over which tasks runs when.

        Common use:
            Serial : Order matter
            Parallel : Order is immaterial (does not matter) 

## Events and Delegates

    Scripting   >   Linear programming
    Graphics    >   Screen Objects

        Event Driven Programming

```xaml
    #<Button x:name="Button01" Click="DoThis">
```

```cs
    Main(){
        private void Button01_Click(Object sender, EventArgs e)
        //sender : Object initiating the event
        //Event Args
    }
```

    a) Trivial Example
    b) OOP Example

### Trivial Example

    1.  Event can trigger on eor more methods. Dont declare method directly but via an agent type which will call named methods.
            Delegate is a pointer object which will point to one or more methods

            Declare delegate    >   Creates a fixed structure for permitted method in/out parameters

            delegate void MyDelegate();         Pointer to methods but only methods matching this form can be part of a delegate object
                                                YES     void DoThis(){}
                                                YES     void DoThat()){}
                                                NO      int AlsoDoThis(){return -1;}
    2.  Declare an event but also specify the in/out patameters for any methods which will be called

        public event MyDelgate MyEvent;
    3.  Attach methods to our events (must match in/out structure)

            MyEvent += Method01;        //Add
            MyEvent += Method02;

            MyEvent -= Method01;        //Remove

## Web

    Web is exciting
        Check out 
            BLAZOR which is C# nativley running in browser
            APIs

        Websites are for human consumption
            Built with 
                HTML - Structure
                CSS - Colour, Animations
                JavaScript - Programming

        API - Application Programming Interface - For machine consumption
            Simply returns data in the form of 
    1. JSON
   
```json
    json
    {
        "field":value,
        "field":value
    }

    [
        {
            "field":value,
            "field":value
        },
        {
            "field":value,
            "field":value
        }
    ]
```

    1. XML

```xml
    <rootElement>                                       <>, Tag, Element
        <item length="1">                               Element with Attribute (length) and Value (1)
            <field otherValue="admin">Value</field>
        </item>
    </rootElement>
```

## Goal for today

    1. Northwind
    2. Entity Framework
    3. Scaffold API from scrathc with hardly any work

### MVC Methodology

    Model
        Database Item > C#      Class matches database Table
                                Northwind Customers > Class Customer

    View
        Display of data to the end user : HTML/CSS/JavaScript + server-side data fed into page (translated into HTML/CSS/JavaScript)

        Server                          Client
        C#/Node/PHP/Java/Python/Ruby
            Render
                Translates raw data 
                into a form suitable 
                for viewing ie. HTML ==> Client for display

    Controller      Look at URL to make sense of it
        https://www.mydomain.com/controller/action/id
                                /customers/Get/         Get without id  = Get all
                                /customers/Get/ALFKI    Get with id     = Get id
                                /customers/Post/        Post with no id = NEW Customer
                                /customers/Post/id      Post with id    = UPDATE
                                          /Put/id       Same as Post with id
                                Customer
        GET = Request is visible in URL
        POST = Request is inside web page data

        Controller:
            1.  Analyse URL
            2.  According to instructions in URL, go and get relevant data from Model
            3.  Send that data to a VIEW PAGE which displays the data

### MVC Summary

    MODEL : DATA
    CONTROLLER : TAKE REQUEST AND RETURN DATA TO VIEW
    VIEW : DISPLAY
  
## API using .NET Core

    Microsoft is stringly pushing .NET Core
        Lets use it to read a database

    Goals
        1.  Code first approahc to build our code and from this to create a database
            a.  SQLSERVER
            b.  SQLite
        2.  Seed data from C# ie create a new database with new data
        3.  Create API

### Set up

    .Net Core 2.1 Web App with API

        Install libraries

## Web Layout

    Traditional HTML web pages looked like:

    HTML Layout

```html
        <div class="navbar"><!--menu--></div>
        <div class="main"><!--main content--></div>
        <div class="footer"><div>
```

    HTML5 Layout
        Semantic tag: sam as div (divison of a page) but just has meaning related to placing and content on a page

            HEADER
            NAV     Nav bar
            SECTION
                ARTICLE
                ASIDE
            FOOTER

        Assistive tech would sometimes use these to help people who need it.
            e.g. Screen readers
            e.g.    <img alt="" title=""/>
                         alt image displayed if origianl failed to load
                         title is displayed on hover and also read out by screen reader
    
    CSS
        <button class="buttonTypeRound"/>

        <style>
        .button{
            border-radius: 5px;
        }
        </style>
    1. FlexBox
        Useful for 1d arrangemtn of items eg navbar or picture gallery

    2. Grid
        Set varying colum widths to fied/auto/match content etc
        Also sssame for rows
        Good for lahying out responsive latout and placing elements with minimum og fuss. Good for centering items easily within page or grid box.

## Homework 2

    a)  Flexboxes
            Rebuild a couple of FLEXBOXES note: can set both horizontal or vertical.
            Check phils showcase for egs.
    b)  GridBoxes
            Got a grid eg in html intro repo
            Build a webpage using grid laypout structure
            Put in three features which can be interacted with using javascript

## Push your website on the internet for free and connect it via github with automatic deployment on change (ie git push)

    build local
        push to github
            deploy to netlify
    change local
        push to github
            automatic redeployment

## Sprints

    BurnUp: list of tasks done
    BurnDown: list of tasks to be done

## Solid Programming Principles

    Theoretical overview of good programming principles.
        Becomes more important on larger projects where up-front theoretical thinking and good practise can save a ton of re-factoring work later on.

    S = SINGLE RESPONSIBILITY ie a class should relate to one object only

        E.G.
            class Rabbit    GOOD
            class Kitchen   BAD         Too vague as different, mutually exclusive subtypes
                    KitchenOpenPlan     Mutually exclusive so use these
                    KitchenClosed

    O = OPEN / CLOSED
        Open for EXTENSTION     (i.e. not sealed)
        Closed for MODIFICATION (dont mess with your original work)

    class A-Class           dont modify if possible
        class ModelA13      both modify original parent
        class ModelA14

    L = LISKOV 
        Okay to replace child with parent instances

    I = USE INTERFACES
        keep interfaces small
            use one method per interface

        E.G.
        IEnumerator     :       GetEnumerator   (countable list with numeric index) : one method only

    D = DEPENDANCY : Depend on Abstract Classes at top of your structure

## Reference / Value Types

    Stack           Primitives / Value Types / Pointers     Fast    Instant disposal

    Heap            Reference Types                         Slower  Garbage collection at intervals

## SQL 2

    SQL Theory 

        4 Categories

        DML Data Manipulation Language
            Basic Queries : SELECT, INSERT, UPDATE, DELETE (CRUD operations)

        DDL Data Definition Language 
            Create data structures ie DAtabase/Table
                CREATE/DROP - database and table ie add new or remove completely
                ALTER         table ie add key/column
                TRUNCATE      remove
                
        DCL Data Control Language
            Permissions       GRANT / REVOKE

        TCL Transaction Control Language
            Group of transactions TOGETHER 
                1.  COMMIT (all of the transactions in the group as a whole) e.g. atm withdrawl is either all commit or nothing
                2.  Rollback to a given point e.g. start of transaction group
                3.  SAVEPOINT : midway point og saving data progression throughout a series of transactions

### Basic Commands

```sql
use db01    /*bring into scope*/
go
drop d01    /*risk of exception if no db present*/
go
drop database if exists db01;
go
create database db01;
go
```

## Data types

Int
Tinyint
Bit             0,1,null
Char(5)         Fixed width IE CustomerID = 'ALFKI'
Varchar(50)     Variable wiodth up to 50 max
Nvar/Nvarchar
Date/Time/DateTime
Blob/Binary     Binary Large Object

??? Float
??? Decimal

### Getting Help

```sql

    #meta data about your table

```

## Docker

    Runs 'containers' which are mini virtual machines

    Virtual Machine > 10GB > has kernel which is very large

    Container > 2GB max, often much less

### Goal

    1.  Pull container from internet conatining SQL server
    2.  Connect to it and run SQL Server
    3.  Talk to Northwind databse on that server

### Commands

```bash
    # get image
    docker pull kcornwall/sqlnorthwind
    # run image
    docker run -d --name sql -p 1433:1433 kcornwall/sqlnorthwind
    # list all images
    docker ps -a
    # start/stop
    docker start sql
    docker stop sql
```

### Connect to Docker Container

        1.  Lightweight: Azure Data Studio
        2.  Heavyweight: SQL Server Managment Studio

### UPDATE

```sql

    UPDATE mytable set name='fred' where id=2;

```

### DELETE

```sql

    DELETE FROM mytable WHERE id=2;

```

### TOP

    ```sql

    SELECT TOP 10 FROM CUSTOMERS;

    ```

### Other Operators

    AND     OR

    <>      or      (NOT EQUAL TO)

    >       <       >=      <=

### DISTINCT

    ```SQL
        SELECT country FROM Customers ORDER BY country
        SELECT distinct country FROM Customers ORDER BY country
    ```

### CONTAINS > SQL 'like' keyword

    ```SQL
        #contains 'abc'
        like '%abc%'
        # start
        like'abc%'
        # end
        like'%abc'
        #does not contain
        not like '%abc%'
    ```

### Multiple Exact Hits

```SQL
    SELECT * FROM Employees WHERE region IN ('wa', 'bc');
```

### Between

```SQL
    SELECT * FROM products where unitprice between 10 and 20;
```

### Thingy

```SQL
SELECT AVG(UnitPrice) as 'Average Price', MIN(UnitPrice)as 'Minimum Price', MAX(UnitPrice) as 'Maximum Price' from Products
```

### Strings

```sql
    substring();
    substring();
```

### Char Index

```sql
    charindex();
```

### Group By... Having

    Order by only works for fields that exist initially, but not on cumilative fields
        So we can find the sum of all units in stock per product category but this field does not exist initially so we cant order by this field
    For cumilative fields
        i.e. SUM/MAX/MIN/AVG/COUNT
    We use 
        GROUP BY (selecting into batches)... 
        HAVING (same as order by)

    Order Matters
        SELECT DISTINCT FROM WHERE
        GROUP BY ... HAVING ...
        ORDER BY...

### Joins

    INNER JOIN = LEFT JOIN

        table1      table
            table1id    table2id

## Normal Form

    Aims to ensure the integrity of data within a data base
        i.e. all of the relationships make sense and all of the data is current and can be found quickly with the right searches
            No duplication of data ect.

### 1st Normal Form

    One field should hold one item of data ONLY
        e.g. two mobile number not two
    ATOMIC
        As smol as possible
            i.e. one unit of data per cell

### 2nd Normal Form

    All keys depend on the primary key

### 3rd Normal Form

    No keys should have any inter-dependant relationships with each other
        e.g. Name, Address, Postcode, City, County
            In theory, the city and the county, actualy are related

            Instead
                Name, Address, Postcode, City

                County
                    City1
                    City2
            
            (This example is usually ignored in practise)

## Sub Queries

    Query within a query: useful for large, long queries.
```sql
    --Find customers with no orders
    select ... from ... where (select ... from...)
```

## Extra Terms

    IDENTITY (1,1)              Autoincrement starting at value 1 and jump by 1 each time
    IDENTITY                    AutoIncrement
    PRIMARY KEY CLUSTERED   :   Only one per primary key

## Connection Strings and Environment Variables

    We can build a connection string

## SQLite

    SQL db are huge
    Install is complex
    Mobile phones cant communicate very easily with local SQL database.

    SQLite hoolds data locally on any small device. Compatible with Unity, IOS, Android etc.

### Commands

    ./sqlite3 //check working okay
    ./sqlite3 TestDatabase //to create

    Within SQLite Environment
        .databases  //Lists all databases
        .tables     //Lists tables

#### Data Types

    int     integer
    varchar
    text
    real    decimal

### Table

    create table testTable(id int, name varchar(10));
    insert into testTable values (1, bob);
    select * From testTable;

### Auto Increment ID (compare IDENTITY in SQL)

    create table Students(
        StudentId integer primary key,
        Name varchar(50)
    );

    insert into Students (Name) values ('Mr. Sparta');
    SELECT * FROM Students; 

### Generate Northwind

```powershell
    ./sqlite3 Northwind.db < Northwind.sql      #Get this file from internet
```

## .NET Core

### PowerShell Commands

    dotnet new console
    dotnet new web
    dotnet new mvc

    dotnet run

### Other Commands

    dotnet build
    dotnet publish

### Equivalent of Nuget

    dotnet add package <<name>>

### Common

    Newtonsoft.json
    Microsoft.EntityFrameworkCore - 2.1.1 //Stable versions
    Microsoft.EntityFrameworkCore.Sqlserver
    Microsoft.EntityFrameworkCore.Sqlite
    Microsoft.EntityFrameworkCore.Design

### Using a library

    MyConsoleApp.exe

        => Get data from libraries in another palce i.e. myLibrary.dll

    /Root/
        /Library/
            /bin/debug/library.dll
        /App/
            /bin/debug/

## Tech on the wqay in

    BLAZOR > c# in browser

## Using Entity with .NET Core

    So far we have used 
        Entity Databse First
            I.e. Create database and pull entity from this
        Creates the EDMX structure (visual database relationships)
            .tt class structure
    
    We are going to now use Entity code first 
        I.E.Create models (Customers.cs, Product.cs)
            Create a DbContext to talk to the database
            Create connection string (location of databse)

            Also Optionally

            Create migrations (changes to our code) which can in turn cause changes to the database.
            Create migrations (changes to our code) which can in turn cause changes to the database.
            Seed databse with raw data from our C# code.

    Note:   Many companies with LEGACY CODE are using .NET Framework

    But :   Many are moving to .NET Core

    Plus :  .Net Core work is EASIER IN FRAMEWORK

## Entity Code First

    We can use this in two ways:
        1.  Easier to get started, Code first from database
            1.  Create SQL
            2.  Create DB with data
            3.  Pull into project
        2.  Harder
            1.  Create models
            2.  Push and crate database
                - From scratch initially 
                - Then update as you go along

## Updating A Databse in Code First

    We run two commands only

        NUGET
            add-migration Initial
            add-migration AddDateField
            update-databse
        POWERSHELL
            add migration
