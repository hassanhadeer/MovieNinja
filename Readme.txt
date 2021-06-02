

    //===================================>>
    //== What we did... our story...

    // created a new webapp
    // cleaned up the project (removed Bootstrap & JQuery)
    // removed extra files (error and privacy pages)
    // cleared the exiting CSS
    // removed any calls to Bootstrap in our _Layout
    // wrote our own CSS (simple CSS)
    // added the Fetch.cs to our Program.cs file
    // added a call to the fetch.GetTrends()  in our index (code behind page)
    // raw JSON was returned yeah!!!

    // called TMDB with: https://api.themoviedb.org/3/trending/all/day?api_key=d194eb72915bc79fac2eb1a70a71ddd3
    // convert the JSON into classes/objects (used this site: https://wtools.io/convert-json-to-csharp-class)
    // added 2 classes, Trend and TrendSet
    // instantiated a TrendSet object in our Program.cs (public static TrendSet trendSet = new TrendSet();)
    
    // next up - displaying results!
    // traverse the objects/classes to display data!
    // shows posters for upcoming/new movies and TV shows

    // add a search form - input button etc...
    // added an OnPostSearch(string search) in our index.cshtml.cs file
    // added a Search method in our fetch.cs 
    // this does a movie search: https://api.themoviedb.org/3/search/movie?api_key=d194eb72915bc79fac2eb1a70a71ddd3&query=Tenet

    // display the movie poster serach results!
    // !add the ability to select a poster (search/trends) => show the details
    // added the GetDetails(string movieID) method to the fetch.cs
    // added 6 more classes: movie, cast, crew, videoset, creditset, video

    // chose to redirect to new page (Details) 
    // solved issue! - movieID not being passed through (nope!)
    // added search icon (ugly icon) - should maybe use fontawesome etc...

    // start the details page with 1 item at a time... backdrop, details, year
    // runtime, rating, director etc...
    // details page - mostly done - meh??
    // still need poster and cast default images! no blanks! poserBackground works without however :)


    /////////////
    // Week 2
    // FIXED! movies and TV shows have mismatched IDs - we need a solution - changed all to movie in the trends
    // api call on line 20 in fetch.cs - suggested by Rui
    // FIXED! some films have very large numbers - int32 -2billion to 2billion // revenue 2.9billion
    // FIXED? overview can be quite large, pushing content out of details page/main *** sorta fixed ***
    // !issue for you :( we must have media queries! sadly :(
    // do we seperate the results? how to we redirect? we would need a completly seperate page for TV show details
    // could still add movie rating/rank, and IMDB info as well

    // created basic/empty page for the actors
    // Actor/Bio page, YouTube vids (optional), facebook, instagram, IMDB links etc... project stuff :)

    ////////////////
    // Backend:
    // create uer accounts - with hashed login/logout, genre pref! faved movies and/or watch later list
    // we could also add a rating! User rating??
    /*      Database generated! we also added a StoredProc.txt to keep our SP's in plain text
            User:
            *userID
            username
            password - hashed
            email
            status

            Watch:
            *watchID
            movieID - tmdb
            poster_path - tmdb
            movieOverview - tmdb
            dateAdded
            status
            &userID

            Rating: tmdb, personal, site
            *ratingID
            vote_count 1000
            vote_average 4500
            rating - personal
            movieID - tmdb
            *userID
    */

    // What SP's will we need? 
    // For the user table
        // login, logout, create, update?
    // For the watch table
        // get the watch list, remove/update items, clear list?, add to the list(insert)
    // For the rating table
        // add a rating, get the rating for a movie (our rating)


    // SQL Server Extention add connection wizard answers: official name SQL Server (mssql)
    // this is published by Microsoft, I do NOT recommend any other for MS SQL Server
    // answers to the wizard:
        // server: (localdb)\ProjectsV13
        // db name: MovieNinjaDB
        // Login type: integrated (SQL Loin when going live)
        // Profile name: MovieNinjaDB (can be whatever)


    // added a CreateUser SP
    // added the join pages
    // added a null check for the searchBox - Allaura

    // user/pass/email/status 
    // ask for a password reset (type the email)

    // !Issue Alert!!! Alert!!! hashing is salting my brain!
    // need a better sample or tutt in class or snippet form! sorry!
    // hashing passwords - hides the true password
    // this is the code sample that we used - it's out of date but should be ok
        // SHA is the most secure
        // MD5 is faster
        // var sha1 = new SHA1CryptoServiceProvider();
        // var sha1data = sha1.ComputeHash(data);
        // To get data as byte array you could use
    
        // var data = Encoding.ASCII.GetBytes(password);
        // and to get back string from md5data or sha1data
    
        // var hashedPassword = ASCIIEncoding.GetString(md5data);
    // here is the latest? certainly the best method:
        // https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
    // .Net secrets (server passwords, connections string w/username and password)
    // connection to DB and call the appropriate SP passing the required params
    // !Note System.Data.SqlClient had to be manually installed - Rui
        // from the console with: dotnet add package System.Data.SqlClient --version 4.8.2 (check version!)


    // added login/logout SP in a new class named dataNinja
    // added watch list SP
    // added the controls to login/logout
    // added an addToWatch button
    // added a global class DataNinja to host our SP's for global access
    // *another way to do this is detailed here: https://stackoverflow.com/questions/61630971/razor-page-global-onget-onpost-net-core
    // thanks Rui :)

    // Friday Fun
    // rating??