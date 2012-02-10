Overview
======
This is framework, hoping to solve a very specific problem: building SQL statements which are easy to validate, refactor and help maximise re-use.

Before coming to write this framework, my experience has been with working with in-house database (leaky) abstraction layers, hand-writing SQL builders within frameworks and also the [mybatis](http://www.mybatis.org/) (previously [Apache iBatis](http://ibatis.apache.org/)). This project has therefore come out of wanting to have the control of writing pure SQL but with the separation and modularity of writing SQL in a framework such as iBatis.

I can foresee that this project could be useful both as a standalone framework to generate SQL to run manually, but also as a feeder into a project to wrap up the execution and mapping of result sets to objects.

Design Principals
===========
Consistency: The feature-set and design should aim to be one-to-one with the MySQL grammar.

Specific: Want to solve a fairly narrow problem, but solve it well. If this works well, then hopefully the same principals could be applied for other such grammars or frameworks. 

Immutability: A single query object should not be able to be modified; rather, new copies should be produced on each modification. This makes the approach more akin to that of functional programming (and F# was also a serious consideration for this project).

Getting Started
==========
I'm currently starting by drawing up some kind of design in the IntegrationTests\Design.cs file. This should act as a pretty good example of the libraries use.