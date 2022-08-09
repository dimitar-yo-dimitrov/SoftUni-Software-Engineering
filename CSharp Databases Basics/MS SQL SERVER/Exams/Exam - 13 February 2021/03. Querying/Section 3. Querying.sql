      USE Bitbucket

-- 05.Commits

   SELECT Id
        , [Message]
        , RepositoryId
		, ContributorId
     FROM Commits
 ORDER BY 1, 2, 3, 4

 -- 06.Front-end

   SELECT Id
        , [Name]
        , Size
     FROM Files
    WHERE Size > 1000 AND [Name] LIKE '%html%'
 ORDER BY Size DESC, Id, [Name]

 -- 07.Issue Assignment

   SELECT i.Id
        , CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee 
     FROM Users AS u
	 JOIN Issues AS i
	   ON i.AssigneeId = u.Id
 ORDER BY i.Id DESC, IssueAssignee

 -- 08.Single Files

   SELECT pk.Id
        , pk.[Name]
        , CONCAT(pk.Size, 'KB') AS Size
     FROM Files AS pk
LEFT JOIN Files AS fk
	   ON pk.Id = fk.ParentId
    WHERE fk.ParentId IS NULL
 ORDER BY Id, [Name], Size DESC

 -- 09.Commits in Repositories

   SELECT
   TOP(5) r.Id
        , r.[Name]
        , COUNT(c.Id) AS Commits  
     FROM Repositories AS r
	 JOIN Commits AS c
	   ON r.Id = c.RepositoryId
	 JOIN RepositoriesContributors AS rc
	   ON r.Id = rc.RepositoryId
 GROUP BY r.Id, r.[Name]
 ORDER BY Commits DESC, r.Id, r.[Name]

 -- 10.Average Size

   SELECT u.Username
        , AVG(f.Size) AS Size
     FROM Users AS u
	 JOIN Commits AS c
	   ON u.Id = c.ContributorId
     JOIN Files AS f
	   ON c.Id = f.CommitId
 GROUP BY u.Username
 ORDER BY Size DESC, u.Username
