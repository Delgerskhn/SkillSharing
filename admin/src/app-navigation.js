export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Blogs',
    items: [
          {
              text: 'Pending',
              path: '/blogs?status=1'
        },
        {
            text: 'Declined',
            path: '/blogs?status=3'
        },
          {
              text: 'Approved',
              path: '/blogs?status=2'
          }
      ],
    icon: 'contains'
  }
  ];
