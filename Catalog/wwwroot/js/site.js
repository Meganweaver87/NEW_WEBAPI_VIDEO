const uri = 'users';
let todos = [];

function getUsers() {

    fetch(uri)
        .then(response => response.json())
        .then(data => _displayUsers(data))
        .catch(error => console.error('Unable to get items.', error));

};

function addUserInfo() {

    const addNameTextbox = document.getElementById('add-name');
    const addDobTextbox = document.getElementById('add-dob');
    const user = {
        name: addNameTextbox.value.trim(),
        dob: addDobTextbox.value
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
    .then(response => response.json())
    .then(() => {
        getUsers();
        addNameTextbox.value = '';
        addDobTextbox.value = '';

    })
    .catch(error => console.error('Unable to add item.', error));

};

function deleteUserInfo(event) {

    event.preventDefault();
    const providedId = event.target.dataset.userId;
    fetch(`${uri}/${providedId}`, {method: 'DELETE'})
    .then(() => getUsers())
    .catch(error => console.error('Unable to delete item.', error));

};

function displayEditForm(event) {

    event.preventDefault();
  
    console.dir(event);
    console.dir(event.target);
    console.log(event.target.dataset);

    const providedId = event.target.dataset.userId;
    const user = todos.find(user => user.id === providedId);


    document.getElementById('edit-id').value = user.id;
    document.getElementById('edit-name').value = user.name;
    document.getElementById('edit-dob').value = user.dob;
    document.getElementById('editForm').style.display = 'block';

};

function updateUserInfo() {

    const userId = document.getElementById('edit-id').value;
    const userInfo = {
        id: parseInt(userId, 10),
        name: document.getElementById('edit-name').value.trim(),
        dob: document.getElementById('edit-dob').value
    };

    fetch(`${uri}/${userId}`, {
        method: 'PUT',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
    body: JSON.stringify(userInfo)
    })
    .then(() => getUsers())
    .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;

};

function closeInput() {

    document.getElementById('editForm').style.display = 'none';

};

function _displayCount(userCount) {

    //if statement (ternary statement) condition ? if : else
    const name = (userCount === 1) ? 'User' : 'Users';
    // What the ternary statement is doing:
    // let name;
    // if(itemCount === 1){
    //   name = 'catalog'
    // }else{
    //   name = 'catalogs'
    // }

    document.getElementById('counter').innerText = `${userCount} ${name}`;

};

function _displayUsers(data) {

    const tBody = document.getElementById('todos');
    const button = document.createElement('button');

    tBody.innerHTML = '';

    _displayCount(data.length);

    data.forEach(user => {

        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = user.isComplete;

        // console.dir(isCompleteCheckbox)
        // console.log(isCompleteCheckbox)

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.dataset.userId = user.id;
        editButton.addEventListener('click', displayEditForm);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.dataset.userId = user.id;
        deleteButton.addEventListener('click', deleteUserInfo);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(user.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        textNode = document.createTextNode(user.dob);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);

    });

    todos = data;
  
};


//////////////////////////////////////////////////////////////////////////////
// const uri = 'users';
// let todos = [];

// function getUsers() {
//     console.log("getusers");
//     fetch(uri)
//         .then(response => response.json())
//         .then(data => _displayUsers(data))
//         .catch(error => console.error('Unable to get items.', error));
// }

// function addUsers() {
//     const addNameTextbox = document.getElementById('add-name');
//     const addDobTextbox = document.getElementById('add-dob');


//     const users = {
//         isComplete: false,
//         name: addNameTextbox.value.trim(),
//         dob: addDobTextbox.value.trim()
//     };

//     fetch(uri, {
//         method: 'POST',
//         headers: {
//             'Accept': 'application/json',
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(users)
//     })
//     .then(response => response.json())
//     .then(() => {
//         getUsers();
//         addNameTextbox.value = '';
//         addDobTextbox.value = '';
//     })
//     .catch(error => console.error('Unable to add item.', error));
// }

// // function deleteUsers(id) {
// //     console.log(`${id}` + "idindeleteusers");
// //     fetch(`${uri}/${id}`, {
// //         method: 'DELETE'
// //     })
// //     .then(() => getUsers())
// //     .catch(error => console.error('Unable to delete item.', error));
// // }

// function deleteUsers(event) {
//     event.preventDefault();
//     const providedId = event.target.dataset.usersId
//     fetch(`${uri}/${providedId}`, {
//       method: 'DELETE'
//     })
//     .then(() => getUsers())
//     .catch(error => console.error('Unable to delete item.', error));
//   }
  
// // function displayEditForm(id) {
// //     const users = todos.find(users => users.id === id);

// function displayEditForm(event) {

//     event.preventDefault();
        
//     console.dir(event)
//     console.dir(event.target)
//     console.log(event.target.dataset)
//     const providedId = event.target.dataset.usersId
    
//     const item = todos.find(item => item.id === providedId);
    
//     document.getElementById('edit-name').value = users.name;
//     document.getElementById('edit-id').value = users.id;
//     document.getElementById('edit-isComplete').checked = users.isComplete;
//     document.getElementById('editForm').style.display = 'block';
// }
  
// function updateUsers() {
//     const usersId = document.getElementById('edit-id').value;
//     const users = {
//         id: parseInt(usersId, 10),
//         // isComplete: document.getElementById('edit-isComplete').checked,
//         name: document.getElementById('edit-name').value.trim(),
//         dob: document.getElementById('edit-dob').value
//     };

//     fetch(`${uri}/${usersId}`, {
//         method: 'PUT',
//         headers: {
//             'Accept': 'application/json',
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(users)
//     })
//     .then(() => getUsers())
//     .catch(error => console.error('Unable to update item.', error));
    
//     closeInput();
    
//     return false;
// }
    
// function closeInput() {
//     document.getElementById('editForm').style.display = 'none';
// }
    
// function _displayCount(usersCount) {
//     const name = (usersCount === 1) ? 'user' : 'users';
//     // const name = (usersCount === 1) ? 'catalog' : 'catalogs';

    
//     document.getElementById('counter').innerText = `${usersCount} ${name}`;
// }

// function _displayUsers(data) {
//     const tBody = document.getElementById('todos');
//     tBody.innerHTML = '';
      
//      _displayCount(data.length);
      
//     const button = document.createElement('button');
      
//     data.forEach(users => {
//         let isCompleteCheckbox = document.createElement('input');
//         isCompleteCheckbox.type = 'checkbox';
//         isCompleteCheckbox.disabled = true;
//         isCompleteCheckbox.checked = users.isComplete;
      
//         let editButton = button.cloneNode(false);
//         editButton.innerText = 'Edit';
//         editButton.dataset.usersId = users.id;
//         editButton.addEventListener('click', displayEditForm)//;
//         //editButton.setAttribute('onclick', `displayEditForm(${users.id})`);
      
//         let deleteButton = button.cloneNode(false);
//         deleteButton.innerText = 'Delete';
//         deleteButton.dataset.usersId = users.id;
//         deleteButton.addEventListener('click', deleteUsers)//;
//         //deleteButton.setAttribute('onclick', `deleteUsers(${users.id})`);
      
//         let tr = tBody.insertRow();
        
//         let td1 = tr.insertCell(0);
//         td1.appendChild(isCompleteCheckbox);
      
//         let td2 = tr.insertCell(1);
//         let textNode = document.createTextNode(users.name);
//         td2.appendChild(textNode);

//         let td3 = tr.insertCell(2);
//         textNode = document.createTextNode(users.dob);
//         td3.appendChild(textNode);

//         let td4 = tr.insertCell(3);
//         td4.appendChild(editButton);

//         let td5 = tr.insertCell(4);
//         td5.appendChild(deleteButton);
//     });

//     users = data;
// }


///////////////////////////////////////////////////////////////////////////////////