Overview
========

* Original Version: qdox-trunk revision 485
* Latest Version: qdox-trunk revision 485
* Download From: http://github.com/marascio/patches/qdox/qdox-114/

Description
===========

QDox does not properly parse the < and > operators after encountering a
'new block'. For example, the following code snippets do not parse:

    int a[] = new int[1 << 16];

or

    Object o = new Object();
    int a = 1 << 30;

This patch updates the lexer to properly account for these situations.
When the lexer tokenizes the input it fails to account for two things:
  
1.  Reset newMode to false when ';' is encountered, within the
    ASSIGNMENT state.
  
2.  Recognize that we are within a bracket, '[', and thus when we
    encounter a '<' or '>' token don't increase our nesting.

Expected output from 'svn stat' after applying this patch and copying
the new FieldTest.java file to the appropriate place:

    ?      src/test/com/thoughtworks/qdox/FieldsTest.java
    M      src/grammar/lexer.flex

License
=======

This patch is Copyright (c) 2008 Louis R. Marascio and is released under
the MIT license (http://www.opensource.org/licenses/mit-license.php).

