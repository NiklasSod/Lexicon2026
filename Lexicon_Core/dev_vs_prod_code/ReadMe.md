
# Development (personal) vs production code (company)

A brief description of some difference between the two.
---
*Development* code made for personal projects can be as structured as a production made one, but I find myself lacking a ticket system, a testing branch, a roadmap.

It more becomes a unorganised list of todos, many things at the same time in mind and most commits pushing directly to dev (prod is for the code that actually is on a website).
___
*Production* code, here we have dev, test and prod branches and always add more branches that never merges to prod directly before going through test. We also test our code and even have a test.websiteName.com to see the changes on test before pushing to prod. This test site is not open to the public. 

We have a team of x size and comunicate every day, creating and updating tickets on a board. We have deadlines and stakeholders, designers and translators to update and keep in the loop. We put extensive logging on to every function and api. We might even do A / B testing or count how many times a user clicks on specific items on the page.