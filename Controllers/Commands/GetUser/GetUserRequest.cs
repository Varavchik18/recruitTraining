using MediatR;

public class GetUserRequest : IRequest<GetUserResponse>
{
  public long IdUser { get; set; }
}