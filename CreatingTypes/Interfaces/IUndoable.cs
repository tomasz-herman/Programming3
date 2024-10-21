namespace Interfaces;

public interface IUndoable
{
    void Undo();
}

public interface IRedoable : IUndoable
{
    void Redo();
}