import pymssql
import wikipedia
import urllib.request
conn = pymssql.connect(host='10.14.2.76', user='adamsbala', password='adamsbala', database='Rental')
cur = conn.cursor()
cur.execute("select Title,Year from Movie where Year > 2010 and Description is not Null and Genre is not null and Year is not null and Director is not null and Cast is not null")
row = cur.fetchall()
conn.close()
for i, item in enumerate(row):
	img = None
	try:
		img = wikipedia.page(str(item[0]) + " (" +str(item[1])+  "film)").images[0]
		print("Found it!")
	except:
		print("Doesn't exist")
	if img is not None:
		urllib.request.urlretrieve(str(img),str(item[0])+".jpg")
