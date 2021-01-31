# CSE 3902 Project

## Set Up
1. Navigate to where you want to put this project and clone this repo:
```
  cd path/to/folder
  git clone https://github.com/SnobbyDragon/CSE3902_SP21
```

2. Navigate inside the repo folder and add a gitignore to not track obj files:
```
  cd CSE3902_SP21
  vim .gitignore
```
Your .gitignore file should contain:
```
  .vs
  TestSln/obj/*
  TestSln/obj/Debug/*
```

## How to Contribute
1. Create a new branch from master  
First check if you're on master using `git branch`; if not, do `git checkout master`
```
    git checkout -b myNewBranch
```

2. Edit your branch. When you're ready, add your changes using
```
  git add myChangedFile
```
and commit using
```
  git commit -m "my message"
```  
If you want to add and commit all your changes, a shortcut is `git commit -am "my message"`

3. Push your changes using
```
  git push
```
(it might tell you to set upstream to origin; in that case, do so)

To get others' changes, go to master branch and pull using `git pull`  
You can see your changes before committing using `git diff`. To only see which files instead of line by line, do `git diff --name-only`.
