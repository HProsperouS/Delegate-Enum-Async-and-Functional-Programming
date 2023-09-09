print("Total amount of salary paid to the Full-Time employees who joined after the year of 1995 after deduction: ${}".format(__import__("functools").reduce(lambda x,y: x + (int(y[-1]) * 0.85), filter(lambda x:x[-2] == "FullTime" and int(x[3].split('/')[2]) > 1995, [i.split('|')for i in open('HRMasterlist.txt', 'r').read().split('\n')]), 0)))

# Explanation
# Retrieve Information of employees into list
# [i.split('|')for i in open('HRMasterlist.txt', 'r').read().split('\n')]

# If the employee is full time and startdate larger than 1995
# filter(lambda x:x[-2] == "FullTime" and int(x[3].split('/')[2]) > 1995, [i.split('|')for i in open('HRMasterlist.txt', 'r').read().split('\n')])

# sum the salary by * 0.85
# __import__("functools").reduce(lambda x,y: x + (int(y[-1]) * 0.85),filteredlist,0)

