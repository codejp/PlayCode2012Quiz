Source Code
===========
[https://github.com/jsakamoto/PlayCode2012Quiz](https://github.com/jsakamoto/PlayCode2012Quiz)

API
===

Media Type
----------
_"Accept"_ request header = "application/json" or "application/xml".

Get all questions
-----------------
[/api/questions](/api/questions)

Get count of all questions
---------------------------
[/api/questions/count](/api/questions/count)

Filter
------
[/api/questions?$filter=Category%20eq%20'F%23'](/api/questions?$filter=Category%20eq%20'F%23')

Sort
------
[/api/questions?$orderby=Body](/api/questions?$orderby=Body)

Top, Skip
---------
[/api/questions?$skip=2&$top=3&$orderby=QuestionID](/api/questions?$skip=2&$top=3&$orderby=QuestionID)

[http://www.odata.org/developers/protocols/uri-conventions](http://www.odata.org/developers/protocols/uri-conventions)

