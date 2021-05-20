import DataGrid from 'devextreme-react/data-grid';
import ODataStore from 'devextreme/data/odata/store';
import { getUser } from '../api/auth';

const employees = [
{
    'ID': 9,
    'Prefix': 'Dr.',
    'FirstName': 'Kent',
    'LastName': 'Samuelson',
    'Position': 'Ombudsman',
    'State': 'Missouri',
    'BirthDate': '1972/09/11'
}];

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
    }];

const serviceUrl = 'http://localhost:5002/api/office';
const user = getUser();
console.log(user)
const blogsStore = new ODataStore({
    url: serviceUrl + '/blogs/status/2',
    key: 'pk',
    onLoaded: () => {
        // Event handling commands go here
    },
    beforeSend: (e) => {
        e.headers = {
            'Authorization': 'Bearer ' + user.data.auth_token
        }
    }
});

export default {
    getBlogs() {
        return blogsStore;
    },
    getTasks() {
        return tasks;
    }
};