#-*- coding:utf-8 -*-
import xlrd
import sys
import string
import os

targetdir = sys.argv[1]

for filepath in sys.argv[2:len(sys.argv)]:
	data = xlrd.open_workbook(filepath)

	dotindex = filepath.rfind(os.path.sep)
	outputpath = filepath
	if dotindex != -1:
		outputpath = filepath[:dotindex]
	else:
		outputpath = "."

	for table in data.sheets():
		nrows = table.nrows
		ncols = table.ncols
		if nrows == 0 or ncols == 0:
			break

		colnames = table.row_values(0)

		print(outputpath)
		fd = open(outputpath + targetdir + table.name + ".xml", "w")

		# fd.write("local ")
		fd.write('<?xml version="1.0" encoding="utf-8" ?>\n')
		#fd.write(table.name)
		fd.write("\n<content>\n")
		for i in xrange(1, nrows):
			if table.cell(i, 0).value == "":
				break
				
			# fd.write("\"")
			# fd.write("\"")
			# fd.write(str(int(string.atof(str(table.cell(i, 0).value)))))
			# fd.write("\"")
	
			col1name = colnames[0]
			fd.write("    <" + col1name +" ")
			coldata = table.row_values(i)

			for j in xrange(0, ncols):
				try:
					value = float(string.atof(str(coldata[j])))
					intvalue = int(value)
					if intvalue == value:
						#fd.write("\"")
						fd.write(colnames[j])
						#fd.write("\"")
						fd.write("=")
						fd.write('"')
						fd.write(str(intvalue))
						fd.write('"')
						if j != ncols-1:
							fd.write(" ")
					else:
						#fd.write("\"")
						fd.write(colnames[j])
						#fd.write("\"")
						fd.write("=")
						fd.write('"')
						fd.write(str(value))
						fd.write('"')
						if j != ncols-1:
							fd.write(" ")
				except:
					strValue = coldata[j].encode("utf-8")
					if strValue != "":
						#fd.write("\"")
						fd.write(colnames[j])
						#fd.write("\"")
						fd.write("=")
						fd.write('"')
						fd.write(strValue)
						fd.write('"')
						if j != ncols-1:
							fd.write(" ")
					
			if i != nrows - 1:
				fd.write("/>\n")
			else:
				fd.write("/>\n")

		fd.write("</content>")
		fd.close()

#raw_input("Enter any key to continue")
