using MediatR;

namespace Mediator.Apllication.Blog_s.Command.DeleteBlog
{
    public class DeleteBlgoCommand : IRequest<int>
    {
        public int ID { get; set; }

        // Add this constructor
        public DeleteBlgoCommand(int id)
        {
            ID = id;
        }
    }
}