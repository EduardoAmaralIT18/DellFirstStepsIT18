export default interface News {
  id: number;
  title: string;
  text: string;
  program: string;
  programId: number;
  author: string;
  authorId: number;
  image?: string;
  date: string;
}
