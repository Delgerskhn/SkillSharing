export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Examples',
    icon: 'folder',
    items: [
      {
        text: 'Profile',
        path: '/profile'
      },
      {
        text: 'Tasks',
        path: '/tasks'
      }
    ]
  }, 
  {
    text: 'Blogs',
    items: [
          {
              text: 'Pending',
              path: '/blogs?status=pending'
          },
          {
              text: 'Approved',
              path: '/blogs?status=approved'
          }
      ],
    icon: 'contains'
  }
  ];
