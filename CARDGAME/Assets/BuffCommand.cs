using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCommand : ICommand
{
    IBuffable _buffableToken;
    Token _token;

    public BuffCommand(IBuffable buffableToken)
    {
        _buffableToken = buffableToken;
    }

    public void Execute()
    {
        _token.Buff();
    }

    public void Undo()
    {
        _token.UnBuff();
    }
}
