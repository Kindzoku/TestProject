# TestProject
For testing purposes

1) Sorting algorithm, required by first part of task located in this file: TestProject/TestProject.Sorting/CardHelpers.cs.
It is splitted in two parts. First part only looks for the first card in a stack. Second part do the rest of the job.
I'm not an algorithm guru, so my algorithms based only on logical conclusions.

As for the complexity, I guess it's something about O(n^2).

2) And here is SQL query, required for the second part of the test task

```SQL
select productid, count(productid) [count]
from (
	select customerid, min([datetime]) as [datetime] from SalesTable
	group by customerid
) as x
inner join SalesTable s on s.customerid = x.customerid and s.[datetime] = x.[datetime]
group by productid
```

Anyways, it was fun. :)