using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public interface IPickable
{
    void OnTriggerEnter2D(Collider2D collision);
    public GameObject GetSelf { get; }
}

