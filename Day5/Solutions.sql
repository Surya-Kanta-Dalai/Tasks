-- Simple Questions: 
-- 1: Write a query to display the member id, member name, city and membership status who are all having life time membership. Hint: Life time membership status is "Permanent".
select MEMBER_ID, MEMBER_NAME, CITY, MEMBERSHIP_STATUS from LMS_MEMBERS where MEMBERSHIP_STATUS='Permanent';

-- 2: Write a query to display the member id, member name who have not returned the books. Hint: Book return status is book_issue_status ='Y' or 'N'.
select member.MEMBER_ID, member.MEMBER_NAME from LMS_MEMBERS member join LMS_BOOK_ISSUE issue on member.MEMBER_ID=issue.MEMBER_ID where issue.book_issue_status='Y';

-- 3: Write a query to display the member id, member name who have taken the book with book code 'BL000002'.
select member.MEMBER_ID, member.MEMBER_NAME from LMS_MEMBERS member join LMS_BOOK_ISSUE issue on member.MEMBER_ID=issue.MEMBER_ID where issue.BOOK_CODE='BL000002';

-- 4: Write a query to display the book code, book title and author of the books whose author name begins with 'P'.
select BOOK_CODE, BOOK_TITLE, AUTHOR from LMS_BOOK_DETAILS where AUTHOR like 'P%';

-- 5: Write a query to display the total number of Java books available in library with alias name "NO_OF_BOOKS".
select count(*) "NO_OF_BOOKS" from LMS_BOOK_DETAILS where BOOK_TITLE like '%Java%';

-- 6: Write a query to list the category and number of books in each category with alias name "NO_OF_BOOKS".
select CATEGORY, count(*) "NO_OF_BOOKS" from LMS_BOOK_DETAILS group by CATEGORY;

-- 7: Write a query to display the number of books published by "Prentice Hall" with the alias name "NO_OF_BOOKS".
SELECT COUNT(*) AS NO_OF_BOOKS FROM LMS_BOOK_DETAILS WHERE PUBLICATION = 'Prentice Hall';

-- 8: Write a query to display the book code, book title of the books which are issued on the date "1st April 2012".
SELECT details.BOOK_CODE, details.BOOK_TITLE FROM LMS_BOOK_DETAILS details JOIN LMS_BOOK_ISSUE issue ON details.BOOK_CODE = issue.BOOK_CODE WHERE issue.DATE_ISSUE = '2012-04-01';

-- 9: Write a query to display the member id, member name, date of registration and expiry date of the members whose membership expiry date is before APR 2013.
SELECT MEMBER_ID, MEMBER_NAME, DATE_REGISTER, DATE_EXPIRE FROM LMS_MEMBERS WHERE DATE_EXPIRE < '2013-04-01';

-- 10: write a query to display the member id, member name, date of registration, membership status of the members who registered before  "March 2012" and membership status is "Temporary"  
SELECT MEMBER_ID, MEMBER_NAME, DATE_REGISTER, MEMBERSHIP_STATUS FROM LMS_MEMBERS WHERE DATE_REGISTER < '2012-03-01' AND MEMBERSHIP_STATUS = 'Temporary';

-- 11: Write a query to display the member id, member name who"s City is CHENNAI or DELHI. Hint: Display the member name in title case with alias name 'Name'.
select MEMBER_ID, MEMBER_NAME "Name" from LMS_MEMBERS where CITY IN('CHENNAI', 'DELHI');
 
-- 12: Write a query to concatenate book title, author and display in the following format - Book_Title_is_written_by_Author.
--Example:  Let Us C_is_written_by_Yashavant Kanetkar
--Hint: display unique books. Use "BOOK_WRITTEN_BY" as alias name.
SELECT DISTINCT BOOK_TITLE + '_is_written_by_' + AUTHOR AS BOOK_WRITTEN_BY FROM LMS_BOOK_DETAILS;

-- 13: Write a query to display the average price of books which is belonging to "JAVA" category with alias name "AVERAGEPRICE".
SELECT AVG(PRICE) AS AVERAGEPRICE FROM LMS_BOOK_DETAILS WHERE CATEGORY = 'JAVA';

-- 14: Write a query to display the supplier id, supplier name and email of the suppliers who are all having gmail account.
SELECT SUPPLIER_ID, SUPPLIER_NAME, EMAIL FROM LMS_SUPPLIERS_DETAILS WHERE EMAIL LIKE '%@gmail.com';

-- 15: Write a query to display the supplier id, supplier name and contact details. Contact details can be either phone 
number or email or address with alias name "CONTACTDETAILS". If phone number is null then display email, 
even if email also null then display the address of the supplier. Hint: Use Coalesce function.  
 
-- 16: Write a query to display the supplier id, supplier name and contact. If phone number is null then display "No" else display "Yes" with alias name "PHONENUMAVAILABLE". Hint: Use NVL2.
SELECT SUPPLIER_ID, SUPPLIER_NAME,
CASE 
    WHEN CONTACT IS NULL THEN 'No'
    ELSE 'Yes'
END AS PHONENUMAVAILABLE
FROM LMS_SUPPLIERS_DETAILS;

Average Questions:
-- 1: Write a query to display the member id, member name of the members, book code and book title of the books taken by them.
select member.MEMBER_ID, member.MEMBER_NAME, details.BOOK_CODE, details.BOOK_TITLE from LMS_BOOK_DETAILS details, LMS_BOOK_ISSUE issue, LMS_MEMBERS member where issue.MEMBER_ID=member.MEMBER_ID AND issue.BOOK_CODE=details.BOOK_CODE;

-- 2: Write a query to display the total number of books available in the library with alias name "NO_OF_BOOKS_AVAILABLE" (Which is not issued). Hint: The issued books details are available in the LMS_BOOK_ISSUE table.
select count(*)-(select count(*) from LMS_BOOK_ISSUE) "NO_OFBOOKS_AVAILABLE" from LMS_BOOK_DETAILS;

-- 3: Write a query to display the member id, member name, fine range and fine amount of the members whose fine amount is less than 100.  
select member.MEMBER_ID, member.MEMBER_NAME, details.FINE_RANGE, details.FINE_AMOUNT from LMS_BOOK_ISSUE issue, LMS_MEMBERS member, LMS_FINE_DETAILS details where issue.MEMBER_ID=member.MEMBER_ID AND issue.FINE_RANGE=details.FINE_RANGE AND details.FINE_AMOUNT<100;

-- 4: Write a query to display the book code, book title and availability status of the "JAVA" books whose edition is "6". Show the availability status with alias name "AVAILABILITYSTATUS". Hint: Book availability status can be fetched from "BOOK_ISSUE_STATUS" column of LMS_BOOK_ISSUE table.
SELECT d.BOOK_CODE, d.BOOK_TITLE, i.BOOK_ISSUE_STATUS AS AVAILABILITYSTATUS FROM LMS_BOOK_DETAILS d LEFT JOIN LMS_BOOK_ISSUE i  ON d.BOOK_CODE = i.BOOK_CODE WHERE d.CATEGORY = 'JAVA' AND d.BOOK_EDITION = 6;

-- 5: Write a query to display the book code, book title and rack number of the books which are placed in rack 'A1' and sort by book title in ascending order.
SELECT BOOK_CODE, BOOK_TITLE, RACK_NUM FROM LMS_BOOK_DETAILS WHERE RACK_NUM = 'A1' ORDER BY BOOK_TITLE ASC;

-- 6: Write a query to display the member id, member name, due date and date returned of the members who has returned the books after the due date. Hint: Date_return is due date and Date_returned is actual book return date.
select member.MEMBER_ID, member.MEMBER_NAME, issue.DATE_RETURN, issue.DATE_RETURNED from LMS_MEMBERS member join LMS_BOOK_ISSUE issue on member.MEMBER_ID=issue.MEMBER_ID where issue.DATE_RETURN<issue.DATE_RETURNED;

-- 7: Write a query to display the member id, member name and date of registration who have not taken any book.
select MEMBER_ID, MEMBER_NAME, DATE_REGISTER from LMS_MEMBERS where MEMBER_ID NOT IN(select distinct MEMBER_ID from LMS_BOOK_ISSUE);

-- 8: Write a Query to display the member id and member name of the members who has not paid any fine in the year 2012.
select MEMBER_ID, MEMBER_NAME from LMS_MEMBERS where MEMBER_ID NOT IN (select issue.MEMBER_ID from LMS_BOOK_ISSUE issue join LMS_FINE_DETAILS details on issue.FINE_RANGE=details.FINE_RANGE where issue.DATE_ISSUE like '%-%-12');

-- 9: Write a query to display the date on which the maximum numbers of books were issued and the number of books issued with alias name "NOOFBOOKS".
SELECT TOP 1 DATE_ISSUE, COUNT(*) AS NOOFBOOKS FROM LMS_BOOK_ISSUE GROUP BY DATE_ISSUE ORDER BY NOOFBOOKS DESC;

-- 10: Write a query to list the book title and supplier id for the books authored by "Herbert Schildt" and the book edition is 5 and supplied by supplier "S01".
select book.BOOK_TITLE, supplier.SUPPLIER_ID from LMS_BOOK_DETAILS book join LMS_SUPPLIERS_DETAILS supplier on book.SUPPLIER_ID=supplier.SUPPLIER_ID where book.AUTHOR="Herbert Schildt" AND book.BOOK_EDITION=5 AND supplier.SUPPLIER_ID='S01';

-- 11: Write a query to display the rack number and the number of books in each rack with alias name "NOOFBOOKS" and sort by rack number in ascending order.
select RACK_NUM, count(*) "NOOFBOOKS" from LMS_BOOK_DETAILS group by RACK_NUM order by RACK_NUM;

-- 12: Write a query to display book issue number, member name, date of registration, date of expiry, book title, category, author, price, date of issue, date of return, actual returned date, issue status, fine amount.
select issue.BOOK_ISSUE_NO, member.MEMBER_NAME, member.DATE_REGISTER, member.DATE_EXPIRE, book.BOOK_TITLE, book.CATEGORY, book.AUTHOR, book.PRICE, issue.DATE_ISSUE, issue.DATE_RETURN, issue.DATE_RETURNED, issue.BOOK_ISSUE_STATUS, fine.FINE_AMOUNT from LMS_BOOK_ISSUE issue, LMS_MEMBERS member, LMS_BOOK_DETAILS book, LMS_FINE_DETAILS fine where issue.MEMBER_ID=member.MEMBER_ID AND issue.BOOK_CODE=book.BOOK_CODE AND issue.FINE_RANGE=fine.FINE_RANGE;

-- 13: Write a query to display the book code, title, publish date of the books which is been published in the month of December.
select BOOK_CODE, BOOK_TITLE, PUBLISH_DATE from LMS_BOOK_DETAILS where PUBLISH_DATE like '%-DEC-%';

-- 14: Write a query to display the book code, book title and availability status of the "JAVA" books whose edition is "5". Show the availability status with alias name "AVAILABILITYSTATUS". Hint: Book availability status can be fetched from "BOOK_ISSUE_STATUS" column of LMS_BOOK_ISSUE table.
select BOOK_CODE, BOOK_TITLE, "AVAILABILITYSTATUS" from LMS_BOOK_DETAILS where BOOK_EDITION=5;

Complex Questions:
-- 1: Write a query to display the book code, book title and supplier name of the supplier who has supplied maximum number of books.
-- For example: if "ABC Store" supplied 3 books, "LM Store" has supplied 2 books and "XYZ Store" has supplied 1 book. So "ABC Store" has supplied maximum number of books, hence display the details as mentioned below.
SELECT b.BOOK_CODE, b.BOOK_TITLE, s.SUPPLIER_NAME FROM LMS_BOOK_DETAILS b JOIN LMS_SUPPLIERS_DETAILS s ON b.SUPPLIER_ID = s.SUPPLIER_ID
WHERE s.SUPPLIER_ID = (
    SELECT TOP 1 SUPPLIER_ID
    FROM LMS_BOOK_DETAILS
    GROUP BY SUPPLIER_ID
    ORDER BY COUNT(*) DESC
);

-- 2: Write a query to display the member id, member name and number of remaining books he/she can take with "REMAININGBOOKS" as alias name. Hint:  Assuming a member can take maximum 3 books.  For example, Ramesh has already taken 2 books; he can take only one book now. Hence display the remaining books as 1 in below format.
-- Example:  
-- MEMBER_ID             MEMBER_NAME           REMAININGBOOKS 
-- LM001                        RAMESH                     1 
-- LM002                        MOHAN                     3 
SELECT m.MEMBER_ID, m.MEMBER_NAME, 3 - COUNT(i.BOOK_CODE) AS REMAININGBOOKS FROM LMS_MEMBERS m LEFT JOIN LMS_BOOK_ISSUE i ON m.MEMBER_ID = i.MEMBER_ID AND i.BOOK_ISSUE_STATUS = 'Y' GROUP BY m.MEMBER_ID, m.MEMBER_NAME;

-- 3: Write a query to display the supplier id and supplier name of the supplier who has supplied minimum number of books.
-- For example, if "ABC Store" supplied 3 books, "LM Store" has supplied 2 books and "XYZ Store" has supplied 1 book. So "XYZ Store" has supplied minimum number of books, hence display the details as mentioned below.  
-- Example:
-- SUPPLIER_ID SUPPLIER_NAME 
-- S04 XYZ STORE
SELECT SUPPLIER_ID, SUPPLIER_NAME FROM LMS_SUPPLIERS_DETAILS
WHERE SUPPLIER_ID = (
    SELECT TOP 1 SUPPLIER_ID
    FROM LMS_BOOK_DETAILS
    GROUP BY SUPPLIER_ID
    ORDER BY COUNT(*) ASC
);
