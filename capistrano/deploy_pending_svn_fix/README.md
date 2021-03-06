Overview
========

* Original Version: capistrano-2.0.0
* Latest Version: capistrano-trunk revision 7722
* Download From: http://github.com/marascio/patches/capistrano/deploy_pending_svn_fix/

Description
===========

When using subversion (I haven't tested other SCM's) the deploy:pending
task is off by one in the log that it shows. Subversion's log command
will always show at least one log message if it is invoked. For example,
if the current revision is 10 and HEAD=10, then 'svn log -r 10:HEAD'
will show the commit message for revision 10.

This results in the output of the deploy:pending task being misleading.
In the above example, if my deployed revision is also 10 and I invoked
deploy:pending I would see the commit message for 10 as if 10 was not
yet deployed.

This patch modifies deploy.rb and subversion.rb. Primarily, the patch
will only issue an 'svn log' command if the deployed revision plus one
is less than or equal to the current HEAD revision number. For example,
if the deployed revision is 300 and HEAD is 301 then 'svn log' is
invoked with a revision range of 301:301. Further, if revision 301 is
deployed then no 'svn log' command is invoked.

License
=======

This patch is Copyright (c) 2007 Louis R. Marascio and is released under
the MIT license (http://www.opensource.org/licenses/mit-license.php).

