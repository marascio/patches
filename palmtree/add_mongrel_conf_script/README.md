Overview
========

* Original Version: palmtree-0.0.6
* Latest Version: palmtree-0.0.6
* Download From: http://github.com/marascio/patches/palmtree/add_mongrel_conf_script/

Description
===========

Patch the mongrel_cluster recipes distributed with the Palmtree
Capistrano recipes gem (http://rubyforge.org/projects/palmtree) to
provide a configuration option for specifying mongrel_rails -S command
line option.

This patch adds a new configuration option, :mongrel_conf_script, that
can be set in your Capistrano recipe, for example: 

    set :mongrel_conf_script, "#{deploy_to}/current/config/mongrel.conf"

If this is set when you run the mongrel:cluster:configure task the
generated mongrel_cluster.yml will contain a line similiar to:

    config_script: /var/www/app/current/config/mongrel.conf

License
=======

This patch is Copyright (c) 2007 Louis R. Marascio and is released under
the MIT license (http://www.opensource.org/licenses/mit-license.php).

