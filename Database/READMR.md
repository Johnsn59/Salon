# Salon Database

## Phsical Database Design
<hr>
[Physical Design](SalonPhysicalDatabase.png)
<hr>
### Drop and Create Database

```sql
USE master;
GO

DROP DATABASE IF EXISTS Salon;

CREATE DATABASE Salon;
GO

USE Salon;
GO

CREATE SCHEMA Products AUTHORIZATION dbo;
GO
CREATE SCHEMA Sales AUTHORIZATION dbo;
GO

```
```

```

Images
Format: ![Alt Text](url)

Headers
# This is an <h1> tag
## This is an <h2> tag
###### This is an <h6> tag
  
Emphasis
*This text will be italic*
_This will also be italic_
**This text will be bold**
__This will also be bold__
_You **can** combine them_

Lists
Unordered
* Item 1
* Item 2
  * Item 2a
  * Item 2b
Ordered
1. Item 1
1. Item 2
1. Item 3
   1. Item 3a
   1. Item 3b
