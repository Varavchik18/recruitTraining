using System;
using System.Runtime.Serialization;

[Serializable]
public class NotFoundException : Exception
{
  private long idUser;

  public NotFoundException()
  {
  }

  public NotFoundException(string? message) : base(message)
  {
  }

  public NotFoundException(string v, long idUser) : base($"The {v} with Id: {idUser} is not found")
  {
    this.idUser = idUser;
  }

  public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}
