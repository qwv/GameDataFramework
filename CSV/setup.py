from distutils.core import setup  
import py2exe  
import sys

includes = ['encodings', 'encodings.*', 'sys', 'os', 'xlrd', 'string']
sys.argv.append("py2exe")  
options = {"py2exe":
               {
                   "bundle_files": 3,
                   "dll_excludes":["MSVCP90.dll"],
                   "compressed": 1,
                   "optimize": 2,
                   "bundle_files": 1,
                   "includes": includes,
               }
}
setup(options = options,  
      zipfile=None,   
      windows = [{"script":'excelconvertoxml.py'}])