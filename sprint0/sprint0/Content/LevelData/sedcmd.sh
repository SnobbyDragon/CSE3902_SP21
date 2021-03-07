#!/bin/bash
# replaces all instances in the xml files
# s/<text to replace>/<replace with this>/g
find . -type f -name "*.xml" -exec sed -i "" -e "s/<Dungeon ObjectName=\"left statue\"/<Block ObjectName=\"left statue\"/g" {} \;
