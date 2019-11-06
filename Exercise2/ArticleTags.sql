---- PREPARING DATA ----

-- Drop old tables
DROP TABLE IF EXISTS ArticleTags
DROP TABLE IF EXISTS Articles
DROP TABLE IF EXISTS Tags


-- Create tables
CREATE TABLE Articles
(
	ArticleID bigint NOT NULL PRIMARY KEY,
	Subject nvarchar(1000) NOT NULL
	-- Other columns
)

CREATE TABLE Tags
(
	TagID bigint NOT NULL PRIMARY KEY,
	Name nvarchar(100) NOT NULL
	-- Other columns
)

CREATE TABLE ArticleTags
(
	ArticleID bigint NOT NULL REFERENCES Articles,
	TagID bigint NOT NULL REFERENCES Tags,
	PRIMARY KEY (ArticleID, TagID)
)


-- Insert test data 
INSERT INTO Articles (ArticleID, Subject)
SELECT 1, 'Article1' UNION ALL
SELECT 2, 'Article2' UNION ALL
SELECT 3, 'Article3' UNION ALL
SELECT 4, 'Article4'

INSERT INTO Tags (TagID, Name)
SELECT 1, 'Tag1' UNION ALL
SELECT 2, 'Tag2' UNION ALL
SELECT 3, 'Tag3'

INSERT INTO ArticleTags (ArticleID, TagID)
SELECT 1, 1 UNION ALL
SELECT 1, 2 UNION ALL
SELECT 1, 3 UNION ALL
SELECT 2, 1 UNION ALL
SELECT 2, 2 UNION ALL
SELECT 3, 3


---- RESULT QUERY ----
SELECT a.Subject, t.Name
FROM Articles AS a
LEFT JOIN ArticleTags AS at ON at.ArticleID = a.ArticleID
LEFT JOIN Tags AS t ON t.TagID = at.TagID