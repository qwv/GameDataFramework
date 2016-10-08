    
# -*- coding:utf-8 -*-

import sys
import os
import shutil

def replaceFile(source, dist):
    f1 = open(source, 'rb')
    f2 = open(dist, 'wb')
    f2.write(f1.read())
    f1.close()
    f2.close()

def cur_file_dir():
    path = sys.path[0]
    if os.path.isdir(path):
        return path
    elif os.path.isfile(path):
        return os.path.dirname(path)

def copyFolder(source, dist):
    if not os.path.exists(dist):
        os.mkdir(dist)
    for item in os.listdir(source):
        sourcef = os.path.join(source, item)
        targetf = os.path.join(dist, item)
        if os.path.isdir(sourcef):
            copyFolder(sourcef, targetf)
        elif os.path.isfile(sourcef):
            replaceFile(sourcef, targetf)
			
			
sourcedir = sys.argv[1]
targetdir = sys.argv[2]
copyFolder(cur_file_dir() + sourcedir, cur_file_dir() + targetdir)
