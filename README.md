# TestProject
For testing purposes

And here is SQL query, required for the second part of the test task

```SQL
select productid, count(productid) [count]
from (
	select customerid, min([datetime]) as [datetime] from SalesTable
	group by customerid
) as x
inner join SalesTable s on s.customerid = x.customerid and s.[datetime] = x.[datetime]
group by productid
```
