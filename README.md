[![Coverage Status](https://coveralls.io/repos/github/zachdimitrov/tennis-links/badge.svg?branch=master)](https://coveralls.io/github/zachdimitrov/tennis-links?branch=master)

[![Build status](https://ci.appveyor.com/api/projects/status/igtexou4ht7mmncc?svg=true)](https://ci.appveyor.com/project/zachdimitrov/tennis-links)

# tennis-links

## Telerik Academy 2016-2017
### Web applications with ASP.NET MVC course project

### Project Description
Connect with other tennis players near you. Search for a partner to play with.
### Usage  
**Not authorized**

- View front page
- View site info and contacts

**For regular users**  

- Login/Register new user
- View messages Inbox/Outbox
- Filter all other players by:
  - Name
  - City (select from list)
  - Favorite club (select from list)
  - Skill Level (select from list)
  - Time of availability (select from list)
- Update profile details
- Browse all players
- Send Message to other player
- Add player to favorites
- View site info and contacts

**For admin users**

- All for regular users
- View `Administration` page
- Tables with info for:
  - Users
  - Cities
  - Clubs
- Create new items
  - City
  - Club

### Todo: ideas from trainer on project defence
- refactor repository pattern, use IDbSets instead of EfRepository
- add IMsSqlDbContect to ninject autoconfig - (typeof(),typeof()) and use it
- substitute MVC User classes with interfaces
- add 404 error page (shows server error now)
- add login inviter when someone try to open authorised link (shows error now)~
- add cities predefined table to search city from
- add signalr notifications
- use google api for position

### Todo: known bugs
- ~allow creation of message with empty recipient name~
- ~received messages are not displayed on Azure Deployed app (works locally!)~
- ~small user boxes don't arrange properly, large blank spaces appear~

### Resources
- [Skill Levels](https://www.tenniscanada.com/wp-content/uploads/2015/12/Self-Rating-Guide-English.pdf)
- [Court Surfaces](http://www.itftennis.com/technical/courts/classified-surfaces/about-court-pace-classification.aspx)
- [Tennis Clubs in Bulgaria](http://bgtennis.bg/images/Kategorii_klubove_2017.pdf)

### Created by
name | nickname
:--- | :---
[Захари Димитров](https://telerikacademy.com/Users/ZachD) | **ZachD**  
