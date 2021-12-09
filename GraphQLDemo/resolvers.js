const db = require('./db');


const Query = {
   test: () => 'Test Success, GraphQL server is up & running !!',
   students:() => db.students.list(),
   studentById:(root,args,context,info) => {
      return db.students.get(args.id);
   },
   showQueryVariable:(root,args,context,info) =>
       "The variable is: " +args.testVariable
};

const Student = {
   college:(root) => {
      return db.colleges.get(root.collegeId);
   },

   fullName:(root,args,context,info) => {
      return root.firstName+ " " +root.lastName;
   }
};

const Mutation = {
   createStudent:(root,args,context,info) => {
      return db.students.create({collegeId:args.collegeId,
         firstName:args.firstName,
         lastName:args.lastName,
         email:args.email})
   }
}
module.exports = {Query, Student, Mutation}