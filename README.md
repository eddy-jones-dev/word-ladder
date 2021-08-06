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


#### 5. Future Enhancements

  -  Extract consts (valid word length etc.) into a config file and use `IOptions` to generate a typed settings object.
  -  Have console prompt for another pair of words rather than needing to restart app.
  -  Investigate more efficient graph creation methods, or word ladder retrieval.