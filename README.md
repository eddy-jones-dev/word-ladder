# Word Ladder

## Blue Prism Technical Test - Readme

### Notes

#### 1. Print out task, highlight key areas with regards to requirements.
  - Console App (C# .Net Core)
    - Command Line Args
        - Validate: 4 arguments
        - Validate: `DictionaryFile` should exist
        - Validate: `StartWord` and `EndWord` should be 4 characters
    - Find shortest path between `StartWord` and `EndWord`, using only words from `DictionaryFile`
    - Calculate all possibilities and then return the shortest.
    - Should produce a tree of results - calculate shortest via Levenshtein distance or Breadth-First Search?
    - Discard all words < or > 4 characters
    - ResultFile should include `StartWord` and `EndWord`
  - Unit Tests - should be TDD
  - Maintainable & readable
  - Readme file (this doc)
  - Publish via Github
  - Consider performance (handling file contents, tree traversal)
#### 2. Examine words list
  - ~ 27000 rows
  - Mix of capitalisation
  - Includes punctuation
  - Includes numbers
  - Includes special characters
  - File not in alphabetical order
#### 3. For Investigation
  - ~~Levenshtein distance. Would need to factor in only words in dictionary.~~
  - BFS - typically used to navigate paths through nodes/trees.
  - Performance of string array options, storage/memory.
  - Shortest route might(?) involve changing first letter, therefore don't filter dictionary by first letter of `StartWord`
  - ~~Named/typed parameters in Console app?~~
#### 4. Plan Process
  - Create console app and test project
  - Identify any test nuget packages required (XUnit, FluentAssertions)
  - Validate params
  - Load dictionary file
  - Filter file to relevant `validWords` set
  - Create graph of linked words
  - Work out path from start to end - make part of graph nodes?
  - Log output to file (and console)
#### 5. Future Enhancements
  -  Tests are importing a file from the file system - ideally this would be static data in the solution
  -  ~~Extract consts (valid word length etc.) into a config file and use `IOptions` to generate a typed settings object.~~ - DONE
  -  Have console prompt for another pair of words rather than needing to restart app.
  -  Investigate more efficient graph creation methods, or word ladder retrieval.
  -  `GetNextWords` is looping the valid words repeatedly - could this be mapped into something better to query?

### Conclusions

#### Time Spent: ~ 4 hours split over the course of the week.

I really enjoyed this challenge; it was just enough to get your teeth into and to produce something that would benefit from a proper structured solution. 
I started by working through the question, as noted above, and picking out the relevant criteria so that I could ensure I was producing the right result. 
Having done prior work on speech recognition and translating potentially inaccurate input into domain actions, I was aware of methods including Levenshtein Distance
and Breadth-First search for finding data in a large data set. I came to the conclusion that BFS would be more appropriate given that we were working with 
a particular subset of data and not just finding the theoretical minimum distance. 
Before starting, I also identified from the dictionary file any 'gotchas' that I might need to code against when I came to developing the solution. 

Once it came to development, it was the usual iterative process. I had some concrete rules to work with in terms of input parameters, so these were good 
candidates for TDD and a dedicated validator service. Beyond that, most of the work came in refining the graph modelling method, and trying to determine 
the best way to track not just the number of changes made but also what those changes were. I started with small changesets (spin->spot) and then scaled up 
to check that the methodology was still correct and that performance was still good. The size of the dataset meant that it could be held in memory, I was 
discarding any words that were not 4 characters anyway, but a bigger dataset probably would have necessitated a different approach. Due to the looping 
involved, I had to work on identifying the right places to break out, to increment values, update queues/lists etc. and this was probably the most 
complicated part. The benefit of only being able to tackle the task in 45-60 min intervals meant that there was plenty of thinking time in between to work 
things out in my head!

