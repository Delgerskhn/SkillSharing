import CustomStore from 'devextreme/data/custom_store';
import { getBlogsByStatus } from '../api/blogs';



const tasks = [
{
    'ID': 12,
    'Subject': 'Update Sales Strategy Documents',
    'StartDate': '2013/02/20',
    'DueDate': '2013/02/22',
    'Status': 'Completed',
    'Priority': 'Normal',
    'Completion': 100,
    'EmployeeID': 9
},
{
    'ID': 27,
    'Subject': 'Sign Updated NDA',
    'StartDate': '2013/03/20',
    'DueDate': '2013/03/25',
    'Status': 'Need Assistance',
    'Priority': 'Urgent',
    'Completion': 25,
    'EmployeeID': 9
},
{
    'ID': 36,
    'Subject': 'Review Revenue Projections',
    'StartDate': '2013/03/25',
    'DueDate': '2013/04/06',
    'Status': 'Completed',
    'Priority': 'High',
    'Completion': 100,
    'EmployeeID': 9
},
{
    'ID': 60,
    'Subject': 'Refund Request Template',
    'StartDate': '2013/06/17',
    'DueDate': '2014/04/01',
    'Status': 'Deferred',
    'Priority': 'Normal',
    'Completion': 0,
    'EmployeeID': 9
}
];

const getBlogs = (statusPk) => {
    return new CustomStore({
        key: 'pk',
        load: (loadOptions) => {
            console.log(loadOptions)
            // ...
            return getBlogsByStatus(statusPk)
        },
        insert: (values) => {
            // ...
        },
        update: (key, values) => {
            console.log(key, values)
            // ...
        },
        remove: (key) => {
            // ...
        }
    });

}

export { getBlogs }

export default {
    getTasks() {
        return tasks;
    }
};