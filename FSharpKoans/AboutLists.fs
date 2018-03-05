namespace FSharpKoans

open NUnit.Framework

(*
Lists are immutable, ordered, finite sequences of a single type.
*)
// :)
module ``05: I Have Here In My Hand A List`` = 
    [<Test>]
    let ``01 Creating a list (Syntax 1).`` () = 
        let myList = [ "apple"; "grape"; "pear";"biscuit" ]
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
    [<Test>]
    let ``02 Creating a list (Syntax 2).`` () =
        // The consing (::) allows us to add elements or lists to lists
        // The [] is an empty list 
        let myList = "apple"::"grape"::"pear"::"biscuit"::[]
        // [ "queen ] specifies the addition of a single element list 
        let myOtherList = "orange"::"lemon"::"princess"::[ "queen" ]
        let myNextList = "lily"::"sunflower"::[ "daisy"; "carrot" ] // you may use [ and ] symbols on this line.
        // Added the identifier mylist which is bound to "apple"::"grape"::"pear"::"biscuit"::[]
        let myLastList = "naartjie"::"raisin":: myList // DO NOT use [ or ] symbols on this line!
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
        myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
        myNextList |> should equal ["lily"; "sunflower"; "daisy"; "carrot"]
        myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

    [<Test>]
    let ``03 Creating a list (via concatenation).`` () =
        let a = [902; 10]
        let b = [3; 13; 37]
        // Adding 2 list. Try use cons rather, as @ is O(n) and :: is O(1)
        let result = a @ b
        result |> should equal [902; 10; 3; 13; 37]

    [<Test>]
    let ``04 The : : symbol (called "cons") does not modify an existing list`` () = 
        let first = [ "grape"; "peach" ]
        let second = "pear" :: first
        let third = "apple" :: second
        third |> should equal [ "apple"; "pear"; "grape"; "peach" ]
        second |> should equal [ "pear"; "grape"; "peach" ]
        first |> should equal [ "grape"; "peach" ]

    [<Test>]
    let ``05 Pattern-matching a list (Part 1).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        // head :: tail, i.e. just matches head of the list
        let a::_ = fruits
        a |> should equal "apple"

    [<Test>]
    let ``06 Pattern-matching a list (Part 2).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let b::c::_ = fruits
        b |> should equal "apple"
        c |> should equal "peach"

    [<Test>]
    let ``07 Pattern-matching a list (Part 3).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::d::e = fruits
        let test::tail = fruits
        // The _ pattern matches to "apple" but does not bind. d matches to "peach" and binds.
        // e matches to the rest of the list, and binds. 
        d |> should equal "peach"
        e |> should equal ["orange"; "watermelon"; "pineapple"; "tomato"]
        // Below are our extra bullshit testings, to aid understanding 
        test |> should equal "apple"
        tail |> should equal ["peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        
    [<Test>]
    let ``08 Pattern-matching a list (Part 4).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let f::_::_::g::_ = fruits
        f |> should equal "apple"
        g |> should equal "watermelon"

    [<Test>]
    let ``09 Pattern-matching a list (Part 5).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::_::_::h = fruits
        h |> should equal ["watermelon"; "pineapple"; "tomato"]

    [<Test>]
    let ``10 Pattern-matching a list (Part 6).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [i;j;k;l;m;n] = fruits
        i |> should equal "apple"
        j |> should equal "peach"
        k |> should equal "orange"
        l |> should equal "watermelon"
        m |> should equal "pineapple"
        n |> should equal "tomato"

    [<Test>]
    let ``11 Pattern-matching a list (Part 7).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::o::_::[p;q;r] = fruits
        o |> should equal "peach"
        p |> should equal "watermelon"
        q |> should equal "pineapple"
        r |> should equal "tomato"

    [<Test>]
    let ``12 Pattern-matching a list (Part 8).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [_;s;_;_;t;_] = fruits
        s |> should equal "peach"
        t |> should equal "pineapple"

    [<Test>]
    let ``13 Pattern-matching a list (Part 9).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let k =
            match fruits with
            | [a;b;c;d;e] -> "prune"
            | _::t::_::u::_ -> t + u
            | _ -> "fig"
        k |> should equal "peachwatermelon"

    [<Test>]
    let ``14 Creating a list containing a sequence of numbers, and indexing`` () =
        // [start...end] if no step given, default is 1 
        let k = [6..50]
        // [start...step...end]
        let l = [3..3..20]
        k.[3] |> should equal 9
        l.[3] |> should equal 12