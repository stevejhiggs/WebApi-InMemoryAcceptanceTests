WebApi In Memory Acceptance Tests
==============================

In memory acceptance test examples for owin based web api projects.

This shows how owin can be used to run acceptance tests that would normally need to be ran on a server directly in memory. This leads to:

* big speed boosts
* The ability to debug both the test and the target at the same time
* You can alter your code (e.g ioc) directly from your test.

The simple tests have no requirements but the mongo tests will require a locally running instance of mongo db.
